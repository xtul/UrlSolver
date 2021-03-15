using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlSolver.Objects;
using UrlSolver.Stores;

namespace UrlSolver.Controllers {
	[Route("/")]
	public class UrlSolverController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
