namespace Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses
{
    public class GetAllTodosResponse
    {
        public IEnumerable<TodoResponse> Todos { get; init; } = Enumerable.Empty<TodoResponse>();
    }
}
