using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSolver.Objects;
using UrlSolver.Stores;

namespace UrlSolver.Services {
	public static class UrlSolverService {

		/// <summary>
		/// Creates a web scrapper for provided <paramref name="url"/> and retrieves website's info.
		/// </summary>
		public static async Task<UrlSolverResponse> GetWebsiteInfo(string url) {
			var webScrapper = await WebScrapper.Create(url);

			return new UrlSolverResponse {
				Url = webScrapper.GetWebsiteUrl(),
				Title = webScrapper.GetWebsiteTitle()
			};
		}
	}
}
