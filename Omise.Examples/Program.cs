using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Omise.Examples.Examples;

namespace Omise.Examples
{
    class MainClass
    {
        static IEnumerable<Example> examples = new Example[]
        {
            new Accounts(),
            new Balances(),
            new Cards(),
            new Charges(),
            new Charge_Schedules(),
            new Customers(),
            new Disputes(),
            new Events(),
            new Forexes(),
            new Links(),
            new Occurrences(),
            new Recipients(),
            new Refunds(),
            new Schedules(),
            new Searches(),
            new Tokens(),
            new Transactions(),
            new Transfers(),
            new Transfer_Schedules(),
        };

        public static void Main(string[] args)
        {
            foreach (var example in examples)
            {
                runExample(example);
            }
            Console.WriteLine("done running.");
            Console.ReadKey();

            foreach (var example in examples)
            {
                extractExample(example);
            }
            Console.WriteLine("done extracting.");
            Console.ReadKey();
        }

        static void runExample(Example example)
        {
            var type = example.GetType();
            Console.WriteLine($"example: {type.Name}");

            var methods = type
                .GetMethods()
                .Where(m => m.ReturnType == typeof(Task))
                .ToArray();

            foreach (var method in methods)
            {
                runMethod(example, method);
            }
        }

        static void runMethod(Example example, MethodInfo method)
        {
            Console.WriteLine($"running: {method.Name}");
            var result = method.Invoke(example, null) as Task;
            result?.Wait();
        }

        static void extractExample(Example example)
        {
            var name = example.GetType().Name;
            var filename = $"../../Examples/{name}.cs"; // pwd is ./bin/Debug/ (or Release)

            Console.WriteLine($"extracting: {name}");
            var source = File.ReadAllText(filename);
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = tree.GetRoot();

            var methods = root
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where(m => m.Modifiers.Any(mod => mod.Text == "async"))
                .ToArray();

            foreach (var method in methods)
            {
                extractMethod(example, method);
            }
        }

        static void extractMethod(Example example, MethodDeclarationSyntax method)
        {
            var klass = example.GetType().Name;
            var methodName = method.Identifier.ToString();

            var parts = methodName.Split(new[] { "__" }, 2, StringSplitOptions.None);
            var operation = parts[0];
            var name = parts[1];

            Console.WriteLine($"extracting: {klass}.{operation}.{name}");
            var body = method.Body.ToString();
            body = body.Replace(@"            ", ""); // indentation
            body = Regex.Replace(body, @"^{", "");    // opening/closing braces
            body = Regex.Replace(body, @"}$", "");
            body = body.Trim(new[] { ' ', '\r', '\n' });

            WriteSample(body, klass, operation, name);
        }

        static void WriteSample(string code, string klass, string operation, string name)
        {
            klass = klass.ToLower();
            operation = operation.ToLower();
            name = name.ToLower();

            var dir = $"samples/{klass}/{operation}";
            var path = $"{dir}/{name}.cs";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            Console.WriteLine($"writing: {path}");
            Console.WriteLine(code);
            File.WriteAllText(path, code);
        }
    }
}
