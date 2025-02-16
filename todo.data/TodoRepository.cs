using System.Threading.Tasks;

namespace todo.data;

public class TodoRepository
{
    private readonly TodoDBContext _context;

    public TodoRepository(TodoDBContext context)
    {
        _context = context;
    }

    public async Task<Item> CreateTodoAsync(Item todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}

