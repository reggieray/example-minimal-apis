using Examples.MinimalApi.Todo.FastEndpoints.Domain;

namespace Examples.MinimalApi.Todo.FastEndpoints.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken ct);

        Task<TodoItem?> GetByIdAsync(int id, CancellationToken ct);

        Task CreateAsync(TodoItem todo, CancellationToken ct);

        Task UpdateAsync(TodoItem todo, CancellationToken ct);

        Task DeleteAsync(TodoItem todo, CancellationToken ct);
    }
}
