using System;
using System.IO;

namespace Omise.Tests.Util
{
    public class Fixtures
    {
        public static string GetFixturesPath(string filename, string dir = "fixtures")
        {
            // When running via `dotnet test` command
            var path = Environment.CurrentDirectory;

            // When running inside Visual Studio it'll always be in `bin/Debug` dir
            if (Environment.CurrentDirectory.Contains("Omise.Tests/bin/Debug"))
            {
                path = "../../../";
            }

            return Path.GetFullPath(Path.Combine(path, $"testdata/{dir}", filename));
        }
    }
}
