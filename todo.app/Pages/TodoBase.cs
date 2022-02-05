
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace todo.app
{
    public class ToDoBase : ComponentBase
    {



        protected List<Item> Todos = new List<Item>();
  

        Item myitem = new Item();


        protected Item AddItem(string value)
        {


            myitem.Value = value;

            Todos.Add(myitem);

            return myitem;

        }


        public int GenerateUUIDs()
        {

            Random randomUuid = new Random();
            int generatedUuid = randomUuid.Next();
            return generatedUuid;

        }



    }

}
