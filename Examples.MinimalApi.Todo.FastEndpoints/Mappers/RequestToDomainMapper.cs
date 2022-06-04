using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Domain;

namespace Examples.MinimalApi.Todo.FastEndpoints.Mappers
{
    public static class RequestToDomainMapper
    {
        public static TodoItem Map(CreateTodoRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            return new TodoItem
            {
                Name = request.Name,
                IsComplete = request.IsComplete
            };
        }
    }
}
