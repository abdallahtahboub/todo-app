
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace todo.app
{

    public class ToDoBase : ComponentBase
    {

        protected List<Item> Todos = new List<Item>();
        protected List<string> Values = new List<string>();
        protected string Value { get; set; }

        protected void AddItem(string _value)
        {

             Item item = new Item();


            if (string.IsNullOrEmpty(_value))
            {
                  Console.WriteLine("String is Empty");
            }
            else
            {
                item.Value=_value; 
                var val = item.Value;
                _value = Value;
                Todos.Add(item);
                Values.Add(val);
              
            }

         

        }

        public int GenerateUUIDs()
        {

            Random randomUuid = new Random();
            int generatedUuid = randomUuid.Next();
            return generatedUuid;

        }

    }

}
