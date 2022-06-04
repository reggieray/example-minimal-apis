using AutoFixture;
using Examples.MinimalApi.Todo.FastEndpoints.Domain;
using Examples.MinimalApi.Todo.FastEndpoints.Endpoints;
using Examples.MinimalApi.Todo.FastEndpoints.Mappers;
using Examples.MinimalApi.Todo.FastEndpoints.Services;
using FastEndpoints;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.UnitTests
{
    public class GetAllTodosEndpointTests
    {
        [Fact]
        public async Task GetAllTodos_Returns_Todos()
        {
            //Arrange
            var fixture = new Fixture();
            var todoItems = fixture.CreateMany<TodoItem>();
            var expectedResponse = DomainToResponseMapper.Map(todoItems);
            var mockTodoService = new Mock<ITodoService>();
            mockTodoService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(todoItems);
            var ep = Factory.Create<GetAllTodosEndpoint>(mockTodoService.Object);

            //Act
            await ep.HandleAsync(default).ConfigureAwait(false);

            //Assert
            ep.Response.Todos.Should().BeEquivalentTo(expectedResponse.Todos);
        }
    }
}