using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSolver.Stores {
	public class WebScrapperNotCreated : Exception {
        public WebScrapperNotCreated() {
        }

        public WebScrapperNotCreated(string message)
            : base(message) {
        }

        public WebScrapperNotCreated(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
