using Examples.MinimalApi.Todo.MediatR.Data;
using Examples.MinimalApi.Todo.MediatR.Domain;
using Examples.MinimalApi.Todo.MediatR.Dtos;
using MediatR;
using System.Text.Json.Serialization;

namespace Examples.MinimalApi.Todo.MediatR.Handlers
{
    public record GetTodoByIdRequest : IRequest<IResult>
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        public GetTodoByIdRequest(int id)
        {
            Id = id;
        }
    }

    public class GetTodoByIdRequestHandler : IRequestHandler<GetTodoByIdRequest, IResult>
    {
        private readonly TodoDb _db;

        public GetTodoByIdRequestHandler(TodoDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IResult> Handle(GetTodoByIdRequest request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            return await _db.Todos.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken).ConfigureAwait(false)
                is TodoIetm todo
                    ? Results.Ok(new TodoItemDTO(todo))
                    : Results.NotFound();
        }
    }
}
