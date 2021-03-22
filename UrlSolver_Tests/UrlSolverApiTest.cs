using System;
using System.Net.Http;
using System.Threading.Tasks;
using UrlSolver.Objects;
using UrlSolver.Services;
using Xunit;

namespace UrlSolver_Tests {
	public class UrlSolverApiTest {
		
		[Fact]
		public async Task UrlSolverServiceTest() {
			var websiteUrl = @"https://tiny.pl/h2xvk";
			var websiteInfo = (UrlSolverResponse) await UrlSolverService.GetWebsiteInfo(websiteUrl);

			Assert.Equal("https://www.youtube.com/watch?v=dQw4w9WgXcQ", websiteInfo.Url);
			Assert.Equal("Rick Astley - Never Gonna Give You Up (Video) - YouTube", websiteInfo.Title);
		}
	}
}
