using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DualApi.Test
{
    [Collection("Integration Tests")]
    public class DualAPITest
    {
        private readonly WebApplicationFactory<DualAPI.Startup> _factory;

        public DualAPITest(WebApplicationFactory<DualAPI.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnsSuccessAndStatusUp()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<ResponseType>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal("Up", responseObject?.Status);
        }

        private class ResponseType
        {
            public string Status { get; set; }
        }

        [Fact]
        public async Task GetJuros()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/taxaJuros");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseJuros = JsonSerializer.Deserialize<double>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //Assert.NotNull(responseJuros);
            Assert.Equal(0.01, responseJuros);

        }

    }
}
