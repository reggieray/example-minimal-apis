namespace Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses
{
    public class TodoResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public bool IsComplete { get; init; }
    }
}
