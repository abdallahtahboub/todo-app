
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


    public Item UpdateItem(int id, string newValue)
    {
        var item = _Items.FirstOrDefault(t => t.ItemId == id);
        if (item != null)
        {
            item.Value = newValue;
        }
        return item;
    }


    public Item MarkAsCompleted(int id)
    {
        foreach (Item item in _Items)
        {
            if (item.ItemId == id)
            {
                item.IsCompleted = true;
                _Items.Remove(item);
                return item;
            }
        }
        return null;
    }

    public bool DeleteItem(int id)
    {
        var item = _Items.FirstOrDefault(t => t.ItemId == id);
        if (item != null)
        {
            _Items.Remove(item);
            return true;
        }
        return false;
    }


    // To generate Unique ids to help identifying list items and elements whitch helps with test automation.
    public int GenerateUUIDs()
    {
        Random randomUuid = new Random();
        int generatedUuid = randomUuid.Next();
        return generatedUuid;

    }



}

