using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UrlSolver.Objects;
using UrlSolver.Services;

namespace UrlSolver.Controllers {
	[ApiController]
	[Route("/api")]
	public class UrlSolverApiController : ControllerBase {
		private readonly ILogger<UrlSolverApiController> _logger;

		public UrlSolverApiController(ILogger<UrlSolverApiController> logger) {
			_logger = logger;
		}

		[HttpGet]
		public async Task<IApiResponse> Get([FromQuery] string url) {
			if (url is null) {
				return new ErrorResponse {
					Error = "No url found in query."
				};
			}

			url = new UriBuilder(url).Uri.ToString();

			if (!url.StartsWith("http")) {
				return new ErrorResponse {
					Error = "Bad url provided. Please check if http/https is present."
				};
			}

			var result = await UrlSolverService.GetWebsiteInfo(url);

			return result;
		}
	}
}
