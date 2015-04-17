using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Omise
{
    public class VersionInfo
    {
        private static string clientVersion;

        public static string ClientVersion
        {
            get
            {
                if (string.IsNullOrEmpty(clientVersion))
                    clientVersion = GetProductVersion();
                return clientVersion;
            }
        }

        private static string GetProductVersion() {
           var attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
           return attr.InformationalVersion;
        }
    }
}
