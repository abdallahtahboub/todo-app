using Microsoft.EntityFrameworkCore;

namespace todo.data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options) { }

        public TodoDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=todoDB;Username=abdallah;Password='newlife500.700'");
            }
        }

        public DbSet<Item> TodoItems { get; set; }
    }
}
