using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using tax_api.Models;

namespace tax_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TaxCalculationsController : ControllerBase
	{
		private readonly TaxCalculationDbContext _dbDbContext;
		private readonly ILogger<TaxCalculationsController> _logger;

		public TaxCalculationsController(TaxCalculationDbContext dbDbContext, ILogger<TaxCalculationsController> logger)
		{
			_dbDbContext = dbDbContext;
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <summary>
        /// GET All Tax Calculations
        /// </summary>
        /// <param></param>
        /// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TaxCalculation), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var taxCalculations = await _dbDbContext.TaxCalculations.ToListAsync();

            if (taxCalculations == null)
                return NotFound();

            _logger.LogInformation($"Tax calculations returned: {taxCalculations.Count}");

            return Ok(taxCalculations);
        }

		/// <summary>
        /// GET Tax Calculation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaxCalculation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var taxCalculation = await _dbDbContext.TaxCalculations.FindAsync(id);

            if (taxCalculation == null)
                return NotFound();

            _logger.LogInformation($"Tax calculation returned: {taxCalculation.Id}");

            return Ok(taxCalculation);
        }
        
		/// <summary>
        /// POST - Create New tax calculation
        /// </summary>
        /// <param name="TaxCalculation"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
		public async Task<ActionResult<TaxCalculation>> Create([FromBody] TaxCalculation taxCalculation)
        {
			// Required fields
            if (string.IsNullOrEmpty(taxCalculation.PostalCode))
                return BadRequest();

            // Check  postal code 
            var type = new TaxCalculationTypesController().Get().Where(a => a.PostalCode == taxCalculation.PostalCode).FirstOrDefault();
            if(type == null)
                return BadRequest();

            // calculated values
            taxCalculation.Tax = CalculateTax(type, taxCalculation.Income);
			taxCalculation.CalculationDate = DateTime.Now;
			// touch wood
            _dbDbContext.TaxCalculations.Add(taxCalculation);
            await _dbDbContext.SaveChangesAsync();

            _logger.LogInformation($"Tax calculations created: {taxCalculation.Id}");

            return CreatedAtAction(nameof(Get), new {id = taxCalculation.Id}, taxCalculation);
        }

        /// <summary>
        /// Calculate tax
        /// </summary>
        /// <param name="TaxCalculation"></param>
        /// <returns></returns>
		private double CalculateTax(TaxCalculationType taxCalculationType, double income)
        {
            // TODO: Need to store this in config or DB, key-value settings
            double flatRate = 17.5;
            double flatValue = 10000;
            double flatValuerate = 5;
            double flatValueRateThreshhold = 200000;

            // tax init to 0 needed, for progressive nifty loop :-)
			double tax = 0.0;
            
            //Strings :-(
            switch (taxCalculationType.Type)
            {
                case "Flat Rate":
                    tax = income * (flatRate / 100);
                break;
                case "Flat Value":
                    if(income < flatValueRateThreshhold)
                        tax = income * (flatValuerate / 100);
                    else
                        tax = flatValue;
                break;
                case "Progressive":
                    // get progressive tax rates in income range
                    var rates = new TaxCalculationRatesController().Get().Where(t => income >= t.MinIncome);
                    foreach(var rate in rates)
                    {
                        // take the max if income higher for rate OR only take the remainder portion if less than max :D
                        double applicableIncome = income > rate.MaxIncome ? rate.MaxIncome : income - rate.MinIncome;
                        tax += applicableIncome * rate.Rate / 100;
                    }
                break;
            }

            return tax;
        }
	}
}