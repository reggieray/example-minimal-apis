using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;

namespace Examples.MinimalApi.Todo.FastEndpoints.Endpoints
{
    public class UpdateTodoEndpoint : Endpoint<UpdateTodoRequest,TodoResponse>
    {
        private readonly ITodoService _todoService;

        public UpdateTodoEndpoint(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("/todoitems/{id}");
            AllowAnonymous();
            Description(b => b
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status204NoContent)
                .Produces<ErrorResponse>(StatusCodes.Status400BadRequest));
        }

        public override async Task HandleAsync(UpdateTodoRequest req, CancellationToken ct)
        {
            _ = req ?? throw new ArgumentNullException(nameof(req));

            var todo = await _todoService.GetByIdAsync(req.Id, ct).ConfigureAwait(false);

            if (todo is null)
            {
                await SendNotFoundAsync(ct).ConfigureAwait(false);
                return;
            }

            todo.Name = req.Name;
            todo.IsComplete = req.IsComplete;

            await _todoService.UpdateAsync(todo, ct).ConfigureAwait(false);

            await SendNoContentAsync(ct).ConfigureAwait(false);
        }
    }
}
