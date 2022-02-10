
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace todo.app
{

    public class ToDoBase : ComponentBase
    {
        public Item _Item;
        public int _Counter = 0;
        public List<Item> _Items = new List<Item>();

        public List<Item> AddItem(string item)
        {
            

            
            _Item = new Item();
            _Item.ItemId = _Counter++;
            Console.WriteLine(_Counter);
            _Item.Value = item;
            _Items.Add(_Item);

            return _Items;

        }

        public int GenerateUUIDs()
        {

            Random randomUuid = new Random();
            int generatedUuid = randomUuid.Next();
            return generatedUuid;

        }

    }

}
