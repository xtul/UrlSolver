using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace UrlSolver.Stores {
	public class WebScrapper {
		private string BaseUrl { get; set; }
		/// <summary>
		/// The URL that will be scraped.
		/// </summary>
		private string Url { 
			get => HttpUtility.HtmlDecode(BaseUrl);
			set => BaseUrl = HttpUtility.HtmlEncode(value);
		}
		private HtmlDocument Website { get; set; }

		/// <summary>
		/// Creates web scrapper for this URL.
		/// </summary>
		/// <param name="url">A valid website URL.</param>
		/// <returns>A WebScrapper class.</returns>
		public static async Task<WebScrapper> Create(string url) {
			var web = new HtmlWeb();
			var clientHandler = new HttpClientHandler {
				AllowAutoRedirect = false
			};
			var httpClient = new HttpClient(clientHandler);

			var responseUrl = await GetRedirectionUrl(url, httpClient);
			// if there is no redirection header then just go with what user provided
			if (responseUrl is null) {
				responseUrl = url;
			}
			var website = await web.LoadFromWebAsync(responseUrl);

			return new WebScrapper {
				Website = website,
				Url = responseUrl
			};
		}

		private static async Task<string> GetRedirectionUrl(string url, HttpClient client) {
			var response = await client.GetAsync(url);
			var locationExists = response.Headers.TryGetValues("Location", out var location);
			var contentLocationExists = response.Headers.TryGetValues("Content-Location", out var contentLocation);

			if (locationExists) return location.First();
			if (contentLocationExists) return contentLocation.First();

			return null;
		}

		public string GetWebsiteTitle() {
			return Website.DocumentNode.SelectSingleNode("html")?.SelectSingleNode("head")?.SelectSingleNode("title")?.InnerText ?? null;
		}

		public string GetWebsiteUrl() {
			return Url;
		}
	}
}
