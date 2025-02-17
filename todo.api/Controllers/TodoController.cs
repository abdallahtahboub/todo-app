using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.data;

namespace Todo.api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {


        private readonly TodoDBContext _context;

        public TodoController(TodoDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTodo(Item todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.ItemId }, todo);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound(new { message = "Todo item not found" });
            }
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _context.TodoItems.ToListAsync();

            if (!todos.Any())
            {
                return NotFound(new { message = "No todos found" });
            }

            return Ok(todos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound(new { message = "Todo item not found" });
            }

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();

            return todo == null ? NotFound() : Ok("todo item deleted");

        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllItems()
        {
            var allTodos = await _context.TodoItems.ToListAsync();

            if (!allTodos.Any())
            {
                return NotFound(new { message = "No todos found to delete" });
            }

            _context.TodoItems.RemoveRange(allTodos);
            await _context.SaveChangesAsync();

            return Ok(new { message = "All todo items deleted successfully" });
        }








    }
}

