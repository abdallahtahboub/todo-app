
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
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

