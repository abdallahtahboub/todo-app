using Microsoft.AspNetCore.Mvc;
using todo.business;

namespace todo.app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        ToDo todo = new ToDo();
        [HttpGet]
        public Item Get()
        {
            var item = todo.AddItem("Read a book !");
            return item;
        }


    }
}

