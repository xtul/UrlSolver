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
		public static async Task<IApiResponse> GetWebsiteInfo(string url) {
			WebScrapper webScrapper;
			try {
				webScrapper = await WebScrapper.Create(url);
			} catch (BadUrlException) {
				return new ErrorResponse {
					Error = "Bad url."
				};
			}

			var finalUrl = webScrapper.GetWebsiteUrl();
			var title = webScrapper.GetWebsiteTitle();

			var response = new UrlSolverResponse {
				Url = finalUrl,
				Title = title,
				Notes = new List<string>()
			};

			if (finalUrl == url) {
				response.Notes.Add("There was no redirection or redirection is made outside HTTP header.");
			}

			if (title == null) {
				response.Notes.Add("Title is probably dynamically set after the page loads.");
			}

			return response;
		}
	}
}
