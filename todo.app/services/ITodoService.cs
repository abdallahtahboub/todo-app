using System.Collections.Generic;
using System.Threading.Tasks;
using todo.app;





public interface ITodoService
{
    public Task<Item> GetItem();
}






