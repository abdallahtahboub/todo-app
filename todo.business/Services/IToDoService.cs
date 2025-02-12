namespace todo.business.Services;
using todo.data;

public interface IToDoService
{

    public Item AddItem(string item);
    public Item GetItem(int id);
    public void DeleteItem(int id);
    public int GenerateUUIDs();

}


