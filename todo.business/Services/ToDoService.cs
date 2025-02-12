using System;
using System.Collections.Generic;
using System.Linq;
using todo.data;
namespace todo.business.Services;

public class ToDoService : IToDoService
{
    public Item _Item;
    public int _Counter = 1;
    public List<Item> _Items = new();
    public List<Item> _ItemsRetrieved = new();

    public Item AddItem(string item)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            var _Item = new Item();
            _Item.ItemId = _Items.Count + 1;
            _Item.Value = item;
            _Item.IsCompleted = false;

           
        }
         _Items.Add(_Item);
        return _Item;
    }

    public Item GetItem(int id)
    {

        return _Items.FirstOrDefault(t => t.ItemId == id);

    }

    public void DeleteItem(int id)
    {
        foreach (Item item in _Items)
        {
            if (item.ItemId == id)
            {
                _Items.Remove(item);
                _ItemsRetrieved.Add(item);
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

