using LazyCache;
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
		private readonly IAppCache Cache;

		public UrlSolverApiController() {
			Cache = new CachingService();
		}

		[HttpGet]
		public async Task<IApiResponse> Get([FromQuery] string url) {
			if (url is null) {
				return new ErrorResponse {
					Error = "No url found in query."
				};
			}

			// adds http to url if not present
			url = new UriBuilder(url).Uri.ToString();

			IApiResponse result;
			async Task<IApiResponse> websiteInfoGetter() => await UrlSolverService.GetWebsiteInfo(url);
			// heroku likely won't keep the app awake above 30 minutes
			result = await Cache.GetOrAdd($"websiteInfo-{url}", websiteInfoGetter, TimeSpan.FromMinutes(30));

			if (result is null) {
				return new ErrorResponse {
					Error = "Couldn't get website info. Try again later."
				};
			}

			return result;
		}
	}
}
