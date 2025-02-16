using System.Threading.Tasks;

namespace todo.data;

public class TodoRepository
{
    private readonly TodoDBContext _context;

    public TodoRepository(TodoDBContext context)
    {
        _context = context;
    }

}

