using CustomerWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApplication.Context
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Tasks> ToDoTasks { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
