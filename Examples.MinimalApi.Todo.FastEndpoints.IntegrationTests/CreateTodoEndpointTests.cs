using AutoFixture;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class CreateTodoEndpointTests : BaseEndpointTests
    {
        [Fact]
        public async Task CreateTodo_Returns_Created()
        {
            //Arrange
            var createTodo = Fixture.Create<CreateTodoRequest>();

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.PostAsJsonAsync("/todoitems", createTodo).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateTodoWithEmptyName_Returns_BadRequest()
        {
            //Arrange
            var createTodo = new CreateTodoRequest { Name = string.Empty };

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.PostAsJsonAsync("/todoitems", createTodo).ConfigureAwait(false);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task NullCreateTodo_Returns_InternalServerError()
        {
            //Arrange
            CreateTodoRequest? createTodoRequest = null;

            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.PostAsJsonAsync("/todoitems", createTodoRequest).ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
