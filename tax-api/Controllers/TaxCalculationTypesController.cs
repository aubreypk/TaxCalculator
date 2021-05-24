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
	public class TaxCalculationTypesController : ControllerBase
	{

		public TaxCalculationTypesController()
		{
		}

		/// <summary>
        /// GET All Tax Calculation Types liked to postal codes
        /// </summary>
        /// <param></param>
        /// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TaxCalculation), StatusCodes.Status200OK)]
		public List<TaxCalculationType> Get()
		{
			//TODO: store in DB and manage through admin page - SEE TaxCalculationController FOR DB FUNCTIONALITY
            var taxCalculationTypes = new List<TaxCalculationType>()
            {
                new TaxCalculationType(){ Id = 1, PostalCode="7441", Type="Progressive"},
                new TaxCalculationType(){ Id = 2, PostalCode="A100", Type="Flat Value"},
                new TaxCalculationType(){ Id = 3, PostalCode="7000", Type="Flat Rate"},
                new TaxCalculationType(){ Id = 4, PostalCode="1000", Type="Progressive"}
            }; 

			// Not using async (for now) since theres no Data source, just return the list
			return taxCalculationTypes;
		}
	}
}