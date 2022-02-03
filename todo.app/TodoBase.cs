
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace todo.app
{
    public class ToDoBase : ComponentBase
    {

        protected List<string> Todos = new List<string>();
        protected string Value { get; set; }

        protected void AddItem(string value)
        {

            Value = value;

            Todos.Add(value);

        }



    }

}
