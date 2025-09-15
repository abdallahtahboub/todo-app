
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
                return NotFound();

            var dto = new TodoDto(todo.ItemId, todo.Value, todo.IsCompleted);
            return Ok(dto);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTodos()
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
                return NotFound(new { message = "Todo item not found" });

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();            
            return NoContent();
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllItems()
        {
            var allTodos = await _context.TodoItems.ToListAsync();
            if (!allTodos.Any())
                return NotFound(new { message = "No todos found to delete" });

            _context.TodoItems.RemoveRange(allTodos);
            await _context.SaveChangesAsync();
            return Ok(new { message = "All todo items deleted successfully" });
        }

    }
}
