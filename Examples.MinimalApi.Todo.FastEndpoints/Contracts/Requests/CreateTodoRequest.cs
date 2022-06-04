namespace Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests
{
    public class CreateTodoRequest
    {
        public string? Name { get; init; } = default!;
        public bool IsComplete { get; init; } = default!;
    }
}
