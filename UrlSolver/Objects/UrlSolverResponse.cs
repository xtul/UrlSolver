using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSolver.Objects {
	public class UrlSolverResponse : IApiResponse {
		public string Url { get; set; }
		public string Title { get; set; }
		public List<string> Notes { get; set; }
	}
}
