using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo.business.Services;
using todo.data;

namespace chess_api.Controllers
{




    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly IToDoService _todoService;
        public TodoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var todo = _todoService.GetItem(id);

            if (todo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Value))
            {
                return BadRequest("Todo name cannot be empty.");
            }

            var newTodo = _todoService.AddItem(item.Value);

            if (newTodo == null)
            {
                return StatusCode(500, "Failed to create the todo item.");
            }

            return CreatedAtAction(nameof(GetItemById), new { id = newTodo.ItemId }, newTodo);
        }


    }
}

