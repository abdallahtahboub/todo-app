using Microsoft.EntityFrameworkCore;

namespace todo.data
{
    public class ToDoContext : DbContext
    {

       // First Method 
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options){ }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

       

    }
}
