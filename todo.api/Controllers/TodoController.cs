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

        [HttpGet("{id}/ getItem")]
        public IActionResult GetItemById(int id)
        {
            var todo = _todoService.GetItem(id);

            if (todo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(todo);
        }
        [HttpPut("{id}/ UpdateItem")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            if (string.IsNullOrWhiteSpace(updatedItem.Value))
            {
                return BadRequest("Todo name cannot be empty.");
            }

            var updatedTodo = _todoService.UpdateItem(id, updatedItem.Value);

            if (updatedTodo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(updatedTodo);
        }


        [HttpPut("{id}/complete")]
        public IActionResult MarkItemAsCompleted(int id)
        {
            var updatedItem = _todoService.MarkAsCompleted(id);

            if (updatedItem == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(updatedItem);
        }

        [HttpPost("addItem")]
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

        [HttpDelete("{id}/ DeleteItem")]
        public IActionResult DeleteItem(int id)
        {
            bool isDeleted = _todoService.DeleteItem(id);

            if (!isDeleted)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return NoContent(); // 204 No Content response for successful deletion
        }






    }
}

