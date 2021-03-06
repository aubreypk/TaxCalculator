using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tax_api.Controllers
{
	[ApiController]
	[Route("api/")]
	[Route("/")]
	public class DefaultController : ControllerBase
	{
		private readonly ILogger<DefaultController> _logger;

		/// <summary>
        /// Check API status
        /// </summary>
        /// <param></param>
        /// <returns></returns>
		public DefaultController(ILogger<DefaultController> logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public object Get()
		{
			var responseObject = new
			{
				Status = "Up"
			};
			_logger.LogInformation($"Status pinged: {responseObject.Status}");
			return responseObject;
		}
	}
}