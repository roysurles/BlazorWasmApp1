using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace BlazorWasmApp1.Core.Api.UnitTests
{
    public class FeatureOneV1ControllerBasicTests : IClassFixture<WebApplicationFactory<BlazorWasmApp1.Core.Api.Startup>>
    {
        private readonly WebApplicationFactory<BlazorWasmApp1.Core.Api.Startup> _factory;

        public FeatureOneV1ControllerBasicTests(WebApplicationFactory<BlazorWasmApp1.Core.Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Make sure WebApi project starts first...

            // Arrange
            string url = "https://localhost:44390//api/v1/FeaureOne";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
