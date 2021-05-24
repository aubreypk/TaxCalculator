using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Collections.Generic;
using tax_api.Models;

namespace tax_api.Tests
{
    [Collection("Integration Tests")]
    public class TaxCalculationTypesController
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TaxCalculationTypesController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetTypes_ReturnsSuccessAndCounts()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/taxcalculationtypes");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<List<TaxCalculationType>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.Equal(4, responseObject?.Count);
        }
    }
}