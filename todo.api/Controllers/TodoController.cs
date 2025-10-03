namespace Todo.api.Controllers
{
    /// <summary>
    /// Provides CRUD operations for managing Todo items.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]  // v1
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoController"/> class.
        /// </summary>
        /// <param name="context">The database context for Todo items.</param>
        public TodoController(TodoDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Todo item.
        /// </summary>
        /// <param name="dto">The data transfer object containing the value for the new Todo item.</param>
        /// <returns>
        /// A <see cref="CreatedAtActionResult"/> containing the created Todo item.
        /// </returns>
        /// <response code="201">Returns the newly created Todo item.</response>
        /// <response code="400">If the request data is invalid.</response>

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = new Item
            {
                Value = dto.Value,
                IsCompleted = false
            };

            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            var result = new TodoDto(todo.ItemId, todo.Value, todo.IsCompleted);

            return CreatedAtAction(nameof(GetTodoById), new { id = todo.ItemId }, result);
        }

        /// <summary>
        /// Retrieves a Todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the Todo item.</param>
        /// <returns>The requested Todo item if found.</returns>
        /// <response code="200">Returns the requested Todo item.</response>
        /// <response code="400">If the provided ID is invalid.</response>
        /// <response code="404">If the Todo item is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var todo = await _context.TodoItems
                                       .AsNoTracking() // Avoid tracking the entity since we're just reading
                                       .FirstOrDefaultAsync(t => t.ItemId == id);

            if (todo == null)
                return NotFound();

            return Ok(new TodoDto(todo.ItemId, todo.Value, todo.IsCompleted));
        }

        /// <summary>
        /// Updates an existing Todo item.
        /// </summary>
        /// <param name="id">The ID of the Todo item to update.</param>
        /// <param name="dto">The data transfer object containing updated values.</param>
        /// <returns>The updated Todo item.</returns>
        /// <response code="200">Returns the updated Todo item.</response>
        /// <response code="400">If the request data is invalid.</response>
        /// <response code="404">If the Todo item is not found.</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDto>> UpdateTodo(int id, [FromBody] UpdateTodoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
                return NotFound();

            todo.Value = dto.Value;
            todo.IsCompleted = dto.IsCompleted;

            await _context.SaveChangesAsync();

            var result = new TodoDto(todo.ItemId, todo.Value, todo.IsCompleted);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all Todo items.
        /// </summary>
        /// <returns>A list of all Todo items.</returns>
        /// <response code="200">Returns all Todo items.</response>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAllTodos()
        {
            var todos = await _context.TodoItems.ToListAsync();
            var result = todos.Select(t => new TodoDto(t.ItemId, t.Value, t.IsCompleted));
            return Ok(result);
        }

        /// <summary>
        /// Deletes a Todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the Todo item to delete.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Todo item deleted successfully.</response>
        /// <response code="404">If the Todo item is not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);

            if (todo == null)
                return NotFound();

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes all Todo items.
        /// </summary>
        /// <returns>
        /// No content if items are deleted; NotFound if no items exist.
        /// </returns>
        /// <response code="200">All Todo items deleted successfully.</response>
        /// <response code="404">If no Todo items exist.</response>
        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllItems()
        {
            var allTodos = await _context.TodoItems.ToListAsync();
            if (!allTodos.Any())
                return NotFound();

            _context.TodoItems.RemoveRange(allTodos);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
