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
    public class TaxCalculationRatesController
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TaxCalculationRatesController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetTypes_ReturnsSuccessAndCounts()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/taxcalculationrates");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<List<TaxCalculationRate>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.Equal(6, responseObject?.Count);
        }
    }
}