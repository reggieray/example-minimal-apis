using Examples.MinimalApi.Todo.MediatR.Data;
using Examples.MinimalApi.Todo.MediatR.Dtos;
using MediatR;

namespace Examples.MinimalApi.Todo.MediatR.Handlers
{
    public record DeleteTodoRequest : IRequest<IResult>
    {
        public int Id { get; init; }

        public DeleteTodoRequest(int id)
        {
            Id = id;
        }
    }

    public class DeleteTodoRequestHandler : IRequestHandler<DeleteTodoRequest, IResult>
    {
        private readonly TodoDb _db;

        public DeleteTodoRequestHandler(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IResult> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            if (await _db.Todos.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken).ConfigureAwait(false) is Domain.TodoIetm todo)
            {
                _db.Todos.Remove(todo);
                await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return Results.Ok(new TodoItemDTO(todo));
            }

            return Results.NotFound();
        }
    }
}
