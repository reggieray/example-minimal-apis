using Examples.MinimalApi.Todo.MediatR.Data;
using Examples.MinimalApi.Todo.MediatR.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examples.MinimalApi.Todo.MediatR.Handlers
{
    public record GetAllTodosRequest : IRequest<IResult>;

    public class GetAllTodosRequestHandler : IRequestHandler<GetAllTodosRequest, IResult>
    {
        private readonly TodoDb _db;

        public GetAllTodosRequestHandler(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IResult> Handle(GetAllTodosRequest request, CancellationToken cancellationToken)
        {
            var todos = await _db.Todos.Select(x => new TodoItemDTO(x))
                .ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return Results.Ok(todos);
        }
    }
}
