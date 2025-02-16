using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace todo.data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options) { }

        public DbSet<Item> TodoItems { get; set; }
    }
}
