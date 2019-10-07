using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Omise.Models
{
    public static partial class ModelTypes
    {
        // lookup variables
        static readonly IDictionary<string, Type> lookup = new Dictionary<string, Type>();
        static readonly IDictionary<Type, string> reverseLookup = new Dictionary<Type, string>();

        static ModelTypes()
        {
            Initialize();
        }

        static void Initialize()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsSubclassOf(typeof(ModelBase)) && t.Namespace == typeof(ModelTypes).Namespace);

            // Register types
            foreach (var type in types)
            {
                var name = NormalizeName(type.Name);
                lookup[name] = type;
                reverseLookup[type] = name;
            }
        }

        // Normalize class name e.g. BankAccount => "bank_account"
        static string NormalizeName(string name)
        {
            return Regex.Replace(name, @"([A-Z])", m => "_" + m.Value.ToLower()).Substring(1);
        }

        public static Type TypeFor(string name)
        {
            return lookup[name];
        }

        public static string NameFor<T>()
        {
            return NameFor(typeof(T));
        }

        public static string NameFor(Type t)
        {
            return reverseLookup[t];
        }

        public static void Test()
        {

        }
    }
}