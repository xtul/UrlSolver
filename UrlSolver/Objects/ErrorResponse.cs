using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSolver.Objects {
	public class ErrorResponse : IApiResponse {
		public string Error { get; set; }
	}
}
