using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo.business.Services;
using todo.data;

namespace chess_api.Controllers
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


        [HttpPost]
        public async Task<IActionResult> CreateTodo(Item todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.ItemId }, todo);
        }






    }
}

