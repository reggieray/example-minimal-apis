using Microsoft.EntityFrameworkCore;

namespace Examples.MinimalApi.Todo.MediatR.Data
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Domain.TodoIetm> Todos => Set<Domain.TodoIetm>();
    }
}
