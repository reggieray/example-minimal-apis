using Examples.MinimalApi.Todo.FastEndpoints.Domain;
using Microsoft.EntityFrameworkCore;

namespace Examples.MinimalApi.Todo.FastEndpoints.Data
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
