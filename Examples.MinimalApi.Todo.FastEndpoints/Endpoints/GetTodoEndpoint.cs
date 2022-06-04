using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Mappers;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;

namespace Examples.MinimalApi.Todo.FastEndpoints.Endpoints
{
    public class GetTodoEndpoint : Endpoint<GetTodoRequest, TodoResponse>
    {
        private readonly ITodoService _todoService;

        public GetTodoEndpoint(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/todoitems/{id}");
            AllowAnonymous();
            Description(b => b
                .Produces<TodoResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound));
        }

        public override async Task HandleAsync(GetTodoRequest req, CancellationToken ct)
        {
            _ = req ?? throw new ArgumentNullException(nameof(req));

            var todo = await _todoService.GetByIdAsync(req.Id, ct).ConfigureAwait(false);

            if (todo is null)
            {
                await SendNotFoundAsync(ct).ConfigureAwait(false);
                return;
            }

            var response = DomainToResponseMapper.Map(todo);
            await SendOkAsync(response, ct).ConfigureAwait(false);
        }
    }
}
