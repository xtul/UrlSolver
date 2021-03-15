using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UrlSolver.Helpers {
	public static class AssemblyDirectory {
		public static string Get() {
			string codeBase = Assembly.GetExecutingAssembly().Location;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}
	}
}
