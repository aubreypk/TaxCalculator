using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using tax_api.Controllers;
using tax_api.Models;
using Xunit;

namespace tax_api.Tests
{
    [Collection("Integration Tests")]
    public class TaxCalculationsControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private TaxCalculation _modelTaxCalculation;

        public TaxCalculationsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            // This fetches the same single lifetime instantiation used by Controller classes
            var dbContext = _factory.Services.GetRequiredService<TaxCalculationDbContext>();

            // Seed in-memory database with some data just for testing
            var taxCalculation = new TaxCalculation
            {
                Id = 1,
                PostalCode = "1000",
                Income = 8000,
                CalculationDate = DateTime.Now
            };
            dbContext.TaxCalculations.Add(taxCalculation);
            // Commit
            dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetStudent_ReturnsSuccessAndStudent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/taxcalculations/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseTaxCalculation = JsonSerializer.Deserialize<TaxCalculation>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.NotNull(responseTaxCalculation);
            Assert.Equal(_modelTaxCalculation.Id, responseTaxCalculation.Id);
            Assert.Equal(_modelTaxCalculation.PostalCode, responseTaxCalculation.PostalCode);
            Assert.Equal(_modelTaxCalculation.Income, responseTaxCalculation.Income);
            Assert.Equal(_modelTaxCalculation.CalculationDate, responseTaxCalculation.CalculationDate);
        }
    }
}