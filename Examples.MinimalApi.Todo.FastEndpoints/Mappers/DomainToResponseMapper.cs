using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Domain;

namespace Examples.MinimalApi.Todo.FastEndpoints.Mappers
{
    public static class DomainToResponseMapper
    {
        public static TodoResponse Map(TodoItem todo)
        {
            _ = todo ?? throw new ArgumentNullException(nameof(todo));

            return new TodoResponse
            {
                Id = todo.Id,
                Name = todo.Name,
                IsComplete = todo.IsComplete,
            };
        }

        public static GetAllTodosResponse Map(IEnumerable<TodoItem> todos) => new()
        {
            Todos = todos.Select(x => Map(x))
        };
    }
}
