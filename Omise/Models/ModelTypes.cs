using System;

namespace Omise.Models {
    public static partial class ModelTypes {
        // lookup variables initialized in Models.tt template.
        // static readonly IDictionary<string, Type> lookup;
        // static readonly IDictionary<Type, string> reverseLookup;

        public static Type TypeFor(string name) {
            return lookup[name];
        }

        public static string NameFor<T>() {
            return NameFor(typeof(T));
        }

        public static string NameFor(Type t) {
            return reverseLookup[t];
        }
    }
}