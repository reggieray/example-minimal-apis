using Examples.MinimalApi.Todo.MediatR.Data;
using MediatR;

namespace Examples.MinimalApi.Todo.MediatR.Handlers
{
    public record UpdateTodoRequest : IRequest<IResult>
    {
        public int Id { get; init; } = default!;
        public string? Name { get; init; } = default!;
        public bool IsComplete { get; init; } = default!;
    }

    public class UpdateTodoRequestHandler : IRequestHandler<UpdateTodoRequest, IResult>
    {
        private readonly TodoDb _db;

        public UpdateTodoRequestHandler(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IResult> Handle(UpdateTodoRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var todo = await _db.Todos.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken).ConfigureAwait(false);

            if (todo is null) return Results.NotFound();

            todo.Name = request.Name;
            todo.IsComplete = request.IsComplete;

            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Results.NoContent();
        }
    }
}
