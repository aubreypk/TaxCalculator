using System;
using System.Collections.Generic;

namespace tax_api.Models
{
    public class TaxCalculationType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string PostalCode {get; set; }
    }
}