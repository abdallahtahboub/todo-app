using System;
using System.Collections.Generic;
using System.Linq;
using todo.data;
namespace todo.business.Services;

public class ToDoService : IToDoService
{
    public List<Item> _Items = new();
    public Item _item;
    public Item AddItem(string Value)
    {
        _item = new Item
        {
            ItemId = _Items.Count + 1,
            Value = Value,
            IsCompleted = false
        };
        _Items.Add(_item);
        return _item;
    }

    public Item GetItem(int id)
    {
        foreach (Item item in _Items)
        {
            if (item.ItemId == id)
            {
                return item;
            }
        }

        return null;
    }
    public void DeleteItem(int id)
    {
        foreach (Item item in _Items)
        {
            if (item.ItemId == id)
            {
                _Items.Remove(item);
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

