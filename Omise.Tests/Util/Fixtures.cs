using System;
using System.IO;

namespace Omise.Tests.Util
{
    public class Fixtures
    {
        public static string GetFixturesPath(string filename, string dir = "fixtures")
        {
            var path = Environment.CurrentDirectory.EndsWith("omise-dotnet") ? "Omise.Tests" : "../../";

            return Path.GetFullPath(Path.Combine(path, $"testdata/{dir}", filename));
        }
    }
}
