using AutoFixture;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public abstract class BaseEndpointTests
    {
        protected static Fixture Fixture => new();

        protected static async Task<TodoResponse?> CreateTodo(HttpClient client)
        {
            var createTodoRequest = Fixture.Create<CreateTodoRequest>();
            var createdTodoResponse = await client.PostAsJsonAsync("/todoitems", createTodoRequest).ConfigureAwait(false);
            var todoResponse = await createdTodoResponse.Content.ReadFromJsonAsync<TodoResponse>().ConfigureAwait(false);
            return todoResponse;
        }
    }
}
