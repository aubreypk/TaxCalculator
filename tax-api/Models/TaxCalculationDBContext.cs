using System;
using Microsoft.EntityFrameworkCore;

namespace tax_api.Models
{
    public class TaxCalculationDbContext : DbContext
    {
        public TaxCalculationDbContext(DbContextOptions<TaxCalculationDbContext> options) : base(options) { }

        public DbSet<TaxCalculation> TaxCalculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxCalculation>(taxCalculation =>
            {
                taxCalculation.HasKey(tc => tc.Id);
                taxCalculation.Property(tc => tc.Income).IsRequired();
                taxCalculation.Property(tc => tc.PostalCode).IsRequired();
                taxCalculation.Property(tc => tc.CalculationDate).IsRequired();
            });
        }
    }
}