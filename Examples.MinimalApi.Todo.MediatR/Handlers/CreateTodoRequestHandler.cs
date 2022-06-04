using Examples.MinimalApi.Todo.MediatR.Data;
using Examples.MinimalApi.Todo.MediatR.Dtos;
using MediatR;

namespace Examples.MinimalApi.Todo.MediatR.Handlers
{
    public record CreateTodoRequest : IRequest<IResult>
    {
        public string? Name { get; init; } = default!;
        public bool IsComplete { get; init; } = default!;
    }

    public class CreateTodoRequestHandler : IRequestHandler<CreateTodoRequest, IResult>
    {
        private readonly TodoDb _db;

        public CreateTodoRequestHandler(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IResult> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var todoItem = new Domain.TodoIetm
            {
                IsComplete = request.IsComplete,
                Name = request.Name
            };

            _db.Todos.Add(todoItem);
            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var response = Results.Created($"/todoitems/{todoItem.Id}", new TodoItemDTO(todoItem));

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}
