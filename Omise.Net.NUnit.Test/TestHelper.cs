using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Omise.Net.NUnit.Test
{
    public class TestHelper
    {
        static Dictionary<string, string> jsonDict;

        static TestHelper()
        {
            jsonDict = new Dictionary<string, string>();
        }

        public static string GetJson(string filename)
        {
            if (jsonDict.ContainsKey(filename))
                return jsonDict[filename];

            var output = new StringBuilder();
            string filePath = string.Format("{0}/JsonFixtures/{1}", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, filename);
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    output.AppendLine(line);
                }
            }

            var outputString = output.ToString();
            jsonDict.Add(filename, outputString);
            return outputString;
        }
    }
}

