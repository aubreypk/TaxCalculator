using System;
using System.Collections.Generic;

namespace tax_api.Models
{
    public class TaxCalculationRate
    {
        public int Id { get; set; }
        public TaxCalculationType Type { get; set; }
        public double MinIncome {get; set; }
        public double MaxIncome {get; set; }
        public int Rate {get; set; }
    }
}