namespace todo.business.Services;
using todo.data;

public interface IToDoService
{

    public Item AddItem(string item);
    public Item GetItem(int id);
    public Item UpdateItem(int id, string newValue);
    public Item MarkAsCompleted(int id);
    public bool DeleteItem(int id);
    public int GenerateUUIDs();
    


}


