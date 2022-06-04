using AutoFixture;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class DeleteTodoEndpointTests : BaseEndpointTests
    {
        [Fact]
        public async Task DeleteTodo_Returns_NoContent()
        {
            //Arrange
            await using var application = new TodoApplication();
            var client = application.CreateClient();

            var createdTodo = await CreateTodo(client).ConfigureAwait(false);

            //Act
            var response = await client.DeleteAsync($"/todoitems/{createdTodo.Id}").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteTodo_Returns_NotFound()
        {
            //Arrange
            var todoId = Fixture.Create<int>();

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.DeleteAsync($"/todoitems/{todoId}").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
