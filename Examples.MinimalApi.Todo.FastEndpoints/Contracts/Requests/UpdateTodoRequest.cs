namespace Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests
{
    public class UpdateTodoRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; } = default!;
        public bool IsComplete { get; init; } = default!;
    }
}
