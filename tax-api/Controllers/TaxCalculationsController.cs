using System;
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
            var taxCalculation = await _dbDbContext.TaxCalculations.ToListAsync();

            if (taxCalculation == null)
                return NotFound();

            return Ok(taxCalculation);
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
        //public async Task<ActionResult<TaxCalculation>> Create([FromBody] TaxCalculation taxCalculation)
		public async Task<ActionResult<TaxCalculation>> Create([FromBody] TaxCalculation taxCalculation)
        {
			// Required fields
            if (string.IsNullOrEmpty(taxCalculation.PostalCode))
                return BadRequest();

			taxCalculation.CalculationDate = DateTime.Now;
			// touch wood
            _dbDbContext.TaxCalculations.Add(taxCalculation);
            await _dbDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = taxCalculation.Id}, taxCalculation);
        }
	}
}