

namespace Todo.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDBContext _context;
        public TodoController(TodoDBContext context)
        {
            _context = context;
        }

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
        /// Gets a todo item by its ID.
        /// </summary>
        /// <param name="id">The ID of the todo item.</param>
        /// <response code="200">Returns the todo item.</response>
        /// <response code="200">Returns the todo item.</response>
        /// <response code="404">If the todo item is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var todo = await _context.TodoItems
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(t => t.ItemId == id);

            if (todo == null)
                return NotFound();

            return new TodoDto(todo.ItemId, todo.Value, todo.IsCompleted);
        }


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

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAllTodos()
        {
            var todos = await _context.TodoItems.ToListAsync();
            var result = todos.Select(t => new TodoDto(t.ItemId, t.Value, t.IsCompleted));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);

            if (todo == null)
                return NotFound(); // No message needed

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllItems()
        {
            var allTodos = await _context.TodoItems.ToListAsync();
            if (!allTodos.Any())
                return NotFound(); // No message needed

            _context.TodoItems.RemoveRange(allTodos);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
