using Microsoft.AspNetCore.Mvc;
using todo.business;
using todo.data;

namespace chess_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public Item Get()
        {
            var todo = new ToDo();
            var item = todo.AddItem("Read a book !");
            return item;
        }
    }
}

