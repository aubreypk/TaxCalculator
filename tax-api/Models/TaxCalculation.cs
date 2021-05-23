using System;
using System.Collections.Generic;

namespace tax_api.Models
{
    public class TaxCalculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public double Income {get; set; }
        public DateTime CalculationDate {get; set; }
    }
}