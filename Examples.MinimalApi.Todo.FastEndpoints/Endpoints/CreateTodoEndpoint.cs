using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Mappers;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;

namespace Examples.MinimalApi.Todo.FastEndpoints.Endpoints
{
    public class CreateTodoEndpoint : Endpoint<CreateTodoRequest, TodoResponse>
    {
        private readonly ITodoService _todoService;

        public CreateTodoEndpoint(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/todoitems");
            AllowAnonymous();
            Description(b => b
                .Produces(StatusCodes.Status201Created)
                .Produces<ErrorResponse>(StatusCodes.Status400BadRequest));
        }

        public override async Task HandleAsync(CreateTodoRequest req, CancellationToken ct)
        {
            _ = req ?? throw new ArgumentNullException(nameof(req));

            var todo = RequestToDomainMapper.Map(req);

            await _todoService.CreateAsync(todo, ct).ConfigureAwait(false);

            var response = DomainToResponseMapper.Map(todo);

            await SendCreatedAtAsync<GetTodoEndpoint>(new { todo.Id }, response, generateAbsoluteUrl: true, cancellation: ct).ConfigureAwait(false);
        }
    }
}
