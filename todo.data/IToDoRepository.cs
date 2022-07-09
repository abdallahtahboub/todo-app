using System.Collections.Generic;



namespace todo.data
{
    public interface IToDoRepository
    {

        public Item AddToDo(Item todo);
        public Item DeleteItem(int id);
        public Item GetItem(int id);
        public IEnumerable<Item> GetItems();
        public Item UpdateItem(Item item);
        
    }
}
