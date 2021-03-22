using System.Collections.Generic;
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
			};

			var notes = new List<string>();

			if (finalUrl == url) {
				notes.Add("There was no redirection or redirection is made outside HTTP header.");
			}

			if (title is null) {
				notes.Add("Title is probably dynamically set after the page loads.");
			}

			if (notes.Count > 0) {
				response.Notes = notes;
			}

			return response;
		}
	}
}
