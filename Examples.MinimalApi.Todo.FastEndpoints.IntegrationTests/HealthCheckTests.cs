using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    public class HealthCheckTests : BaseEndpointTests
    {
        [Fact]
        public async Task HealthCheck_Returns_Healthy()
        {
            //Arrange
            await using var application = new TodoApplication();
            var client = application.CreateClient();

            //Act
            var response = await client.GetAsync("/healthcheck").ConfigureAwait(false);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            content.Should().Be("Healthy");
        }
    }
}
