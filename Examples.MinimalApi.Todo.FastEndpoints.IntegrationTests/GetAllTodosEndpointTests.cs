using AutoFixture;
using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Responses;
using Examples.MinimalApi.Todo.FastEndpoints.Domain;
using Examples.MinimalApi.Todo.FastEndpoints.Mappers;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class GetAllTodosEndpointTests
    {
        [Fact]
        public async Task GetAllTodos_Returns_OK()
        {
            //Arrange
            await using var application = new TodoApplication();
            var client = application.CreateClient();
            
            //Act
            var response = await client.GetAsync("/todoitems").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllTodos_Returns_Todos()
        {
            // Arange
            var fixture = new Fixture();
            var todoItems = fixture.CreateMany<TodoItem>();
            var expectedResponse = DomainToResponseMapper.Map(todoItems);
            var mockTodoService = new Mock<ITodoService>();
            mockTodoService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(todoItems);

            await using var application = new TodoApplication(x =>
            {
                x.AddScoped(x => mockTodoService.Object);
            });

            var client = application.CreateClient();

            //Act
            var response = await client.GetFromJsonAsync<GetAllTodosResponse>("/todoitems").ConfigureAwait(false);

            //Assert
            response.Todos.Should().BeEquivalentTo(expectedResponse.Todos);
        }
    }
}