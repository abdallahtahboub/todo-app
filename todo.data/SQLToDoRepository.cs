using System;
using System.Collections.Generic;

namespace todo.data
{
    public class SQLToDoRepository : IToDoRepository
    {

        private readonly ToDoContext _Context;

        public SQLToDoRepository(ToDoContext context)
        {
            this._Context = context;
        }

        public Item AddToDo(Item item)
        {
            _Context.Items.Add(item);
            _Context.SaveChanges();
            return item;
        }

        public Item DeleteItem(int id)
        {
            Item todo = _Context.Items.Find(id);

            if (todo != null)
            {
                _Context.Items.Remove(todo);
                 _Context.SaveChanges();

            }

            return todo;
        }

        public Item GetItem(int id)
        {
            Item todo = _Context.Items.Find(id);
            return todo;
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public Item UpdateItem(Item itemToChanege)
        {
            var changedItem = _Context.Items.Attach(itemToChanege);
            changedItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
            return itemToChanege;
        }
    }
}