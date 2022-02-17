
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace todo.app
{

    public class ToDoBase : ComponentBase
    {
        public Item _Item;
        public int _Counter = 1;
        public List<Item> _Items = new();

        public void AddItem(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                _Item = new Item();
                _Item.ItemId = _Counter++;
                _Item.Value = item;
                _Items.Add(_Item);


            }

        }

        public void DeleteItem(int id)
        {


            foreach (Item item in _Items)
            {

                if (item.ItemId == id)
                {

                    _Items.Remove(item);

                    // This break helps avoiding "System.InvalidOperationException" because an 
                    // item is being removed while looping over an item.
                    break;
                }


            }



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
