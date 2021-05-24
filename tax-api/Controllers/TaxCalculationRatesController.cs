using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using tax_api.Models;

namespace tax_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TaxCalculationRatesController : ControllerBase
	{

		public TaxCalculationRatesController()
		{
		}

		/// <summary>
        /// GET All Tax Calculation Rates for progressive tax
        /// </summary>
        /// <param></param>
        /// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TaxCalculation), StatusCodes.Status200OK)]
		public List<TaxCalculationRate> Get()
		{
			//TODO: store in DB and manage through admin page - SEE TaxCalculationController FOR DB FUNCTIONALITY
			// can extend this to cater for other tax types?
            var taxCalculationRates = new List<TaxCalculationRate>()
            {
                new TaxCalculationRate(){ Id = 1, MinIncome=0, MaxIncome=8350, Rate=10},
                new TaxCalculationRate(){ Id = 2, MinIncome=8351, MaxIncome=33950, Rate=15},
                new TaxCalculationRate(){ Id = 3, MinIncome=33951, MaxIncome=82250, Rate=25},
                new TaxCalculationRate(){ Id = 4, MinIncome=82251, MaxIncome=171550, Rate=28},
				new TaxCalculationRate(){ Id = 5, MinIncome=171551, MaxIncome=372950, Rate=33},
                new TaxCalculationRate(){ Id = 6, MinIncome=372951, MaxIncome=Double.MaxValue, Rate=35}
            }; 

			// Not using async (for now) since theres no Data source, just return the list
			return taxCalculationRates;
		}
	}
}