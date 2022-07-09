using System;
using System.Collections.Generic;
using System.Linq;
namespace todo.data
{
    public sealed class TodoRepositoryInMemory : IToDoRepository
    {
        public Item _Item;
        public int _Counter = 1;
        public List<Item> _Items = new();
        public Item AddToDo(Item item)
        {
            if (!string.IsNullOrWhiteSpace(item.Value))
            {
                _Item = new Item();
                _Item.ItemId = _Counter++;
                _Item.Value = item.Value;
                _Items.Add(_Item);
            }
            return _Item;
        }
        public Item DeleteItem(int id)
        {
            foreach (Item item in _Items)
            {
                if (item.ItemId == id)
                {
                    _Item = item;
                    _Items.Remove(item);
                    break;
                }
            }
            return _Item;
        }
        public Item GetItem(int id)
        {
            Item itemToFind = _Items.FirstOrDefault(e => e.ItemId == id);
            return itemToFind;
        }
        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }
        public Item UpdateItem(Item item)
        {
            Item itemToChange = _Items.FirstOrDefault(e => e.ItemId == item.ItemId);
            if (itemToChange != null)
            {
                itemToChange.ItemId = item.ItemId;
                itemToChange.Value = item.Value;
                itemToChange.IsCompleted = item.IsCompleted;
            }
            return item;
        }
    }
}