
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using todo.api;
using todo.business;



namespace todo.app
{

    public class ToDoBase : ComponentBase
    {
        [Inject]

        public ITodoService TodoService { get; set; }
        public ToDo MyTodo { get; set; }

        public void AddItem()
        {

            TodoService.GetItem();


        }

        // To generate Unique ids to help identifying list items and elements whitch helps with test automation.
        public int GenerateUUIDs()
        {

            Random randomUuid = new Random();
            int generatedUuid = randomUuid.Next();
            return generatedUuid;

        }




    }


}


