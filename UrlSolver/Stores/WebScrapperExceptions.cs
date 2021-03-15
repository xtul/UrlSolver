using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlSolver.Stores {
	public class WebScrapperNotCreatedException : Exception {
        public WebScrapperNotCreatedException() {
        }

        public WebScrapperNotCreatedException(string message)
            : base(message) {
        }

        public WebScrapperNotCreatedException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    public class BadUrlException : Exception {
        public BadUrlException() {
        }

        public BadUrlException(string message)
            : base(message) {
        }

        public BadUrlException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
