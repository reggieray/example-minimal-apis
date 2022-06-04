using Examples.MinimalApi.Todo.MediatR.Domain;

namespace Examples.MinimalApi.Todo.MediatR.Dtos
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItemDTO() { }
        public TodoItemDTO(TodoIetm todoItem)
        {
            _ = todoItem ?? throw new ArgumentNullException(nameof(todoItem));
            (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
        }
    }
}
