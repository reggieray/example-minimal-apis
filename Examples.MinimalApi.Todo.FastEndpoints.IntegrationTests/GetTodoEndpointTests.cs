using AutoFixture;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class GetTodoEndpointTests : BaseEndpointTests
    {
        [Fact]
        public async Task GetTodo_Returns_OK()
        {
            //Arrange
            await using var application = new TodoApplication();
            var client = application.CreateClient();

            var createdTodo = await CreateTodo(client).ConfigureAwait(false);

            //Act
            var response = await client.GetAsync($"/todoitems/{createdTodo.Id}").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetTodo_Returns_NotFound()
        {
            //Arrange
            var todoId = Fixture.Create<int>();

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.GetAsync($"/todoitems/{todoId}").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
