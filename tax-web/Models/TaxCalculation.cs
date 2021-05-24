using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace tax_web.Models
{
    public class TaxCalculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public double Income { get; set; }
        public double Tax { get; set; }
        public DateTime CalculatedDate {get; set; }
    }
}