using Microsoft.EntityFrameworkCore;

namespace todo.data
{
    public class ToDoContext : DbContext
    {


        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

       // First Method 
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

       

    }
}
