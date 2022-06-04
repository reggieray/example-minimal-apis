using AutoFixture;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class UpdateTodoEndpointTests : BaseEndpointTests
    {
        [Fact]
        public async Task UpdateTodo_Returns_NoContent()
        {
            //Arrange
            await using var application = new TodoApplication();
            var client = application.CreateClient();

            var createdTodo = await CreateTodo(client).ConfigureAwait(false);

            var updateTodoRequest = Fixture.Create<UpdateTodoRequest>();

            //Act
            var response = await client.PutAsJsonAsync($"/todoitems/{createdTodo.Id}", updateTodoRequest).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateTodoWithNoExistingTodo_Returns_NotFound()
        {
            //Arrange
            var updateTodoRequest = Fixture.Create<UpdateTodoRequest>();

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.PutAsJsonAsync($"/todoitems/{updateTodoRequest.Id}", updateTodoRequest).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
