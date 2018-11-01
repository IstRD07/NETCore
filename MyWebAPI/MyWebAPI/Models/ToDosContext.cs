using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Models
{
    public class ToDosContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public ToDosContext(DbContextOptions<ToDosContext> options)
            : base(options) { }
    }
}
