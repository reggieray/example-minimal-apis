using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;

namespace Examples.MinimalApi.Todo.FastEndpoints.Endpoints
{
    public class DeleteTodoEndpoint : Endpoint<DeleteTodoRequest>
    {
        private readonly ITodoService _todoService;

        public DeleteTodoEndpoint(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("/todoitems/{id}");
            AllowAnonymous();
            Description(b => b
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status204NoContent));
        }

        public override async Task HandleAsync(DeleteTodoRequest req, CancellationToken ct)
        {
            _ = req ?? throw new ArgumentNullException(nameof(req));

            var todo = await _todoService.GetByIdAsync(req.Id, ct).ConfigureAwait(false);

            if (todo is null)
            {
                await SendNotFoundAsync(ct).ConfigureAwait(false);
                return;
            }

            await _todoService.DeleteAsync(todo, ct).ConfigureAwait(false);

            await SendNoContentAsync(ct).ConfigureAwait(false);
        }
    }
}
