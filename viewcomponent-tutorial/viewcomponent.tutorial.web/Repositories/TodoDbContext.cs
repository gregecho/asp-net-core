using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using viewcomponent.tutorial.web.Models;

namespace viewcomponent.tutorial.web.Repositories
{
    public class TodoDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public TodoDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<TodoItem> ToDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("testdb"));
        }
    }
}