using System;
using System.Text;

namespace Omise.Net
{
    internal class Credentials
    {
        public Key PublicKey { get; private set; }
        public Key SecretKey { get; private set; }

        public Credentials(string pkey, string skey) {
            if (string.IsNullOrEmpty(pkey) && string.IsNullOrEmpty(skey))
                throw new ArgumentNullException("skey", "atleast one key must be provided.");
                
            PublicKey = pkey;
            SecretKey = skey;
        }

        public string AuthorizationString() {
            var authline = Encoding.GetEncoding("ISO-8859-1").GetBytes(PublicKey + ":");
            return "Basic " + Convert.ToBase64String(authline);
        }
    }
}

