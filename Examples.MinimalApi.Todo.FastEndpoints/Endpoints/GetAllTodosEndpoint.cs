using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Mappers;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;

namespace Examples.MinimalApi.Todo.FastEndpoints.Endpoints
{
    public class GetAllTodosEndpoint : EndpointWithoutRequest<GetAllTodosResponse>
    {
        private readonly ITodoService _todoService;

        public GetAllTodosEndpoint(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/todoitems");
            AllowAnonymous();
            Description(b => b
                .Produces<TodoResponse>(StatusCodes.Status200OK));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var todos = await _todoService.GetAllAsync(ct).ConfigureAwait(false);
            var response = DomainToResponseMapper.Map(todos);
            await SendOkAsync(response, ct).ConfigureAwait(false);
        }
    }
}
