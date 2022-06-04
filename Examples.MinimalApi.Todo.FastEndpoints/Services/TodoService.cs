using Examples.MinimalApi.Todo.FastEndpoints.Data;
using Examples.MinimalApi.Todo.FastEndpoints.Domain;
using Microsoft.EntityFrameworkCore;

namespace Examples.MinimalApi.Todo.FastEndpoints.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDb _db;

        public TodoService(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken ct) => await _db.Todos.AsNoTracking().ToListAsync(cancellationToken: ct).ConfigureAwait(false);

        public async Task<TodoItem?> GetByIdAsync(int id, CancellationToken ct) => await _db.Todos.FindAsync(new object?[] { id }, cancellationToken: ct).ConfigureAwait(false);

        public async Task CreateAsync(TodoItem todo, CancellationToken ct)
        {
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TodoItem todo, CancellationToken ct)
        {
            _db.Todos.Update(todo);
            await _db.SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task DeleteAsync(TodoItem todo, CancellationToken ct)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync(ct).ConfigureAwait(false);
        }
    }
}
