using System.Text;
using Omise.Net;
using System.Runtime.Remoting.Messaging;
using System;

namespace Omise.Net
{
    public struct Key
    {
        string key;

        public bool IsTest { get { return key.Contains("_test_"); } }

        public bool IsLive { get { return !IsTest; } }

        private Key(string key)
        {
            this.key = key;
        }

        public string AuthorizationHeader()
        {
            var encoded = Encoding.GetEncoding("ISO-8859-1").GetBytes(key + ":");
            return "Basic " + Convert.ToBase64String(encoded);
        }

        public override string ToString()
        {
            return key;
        }

        public static implicit operator string(Key k)
        {
            return k.ToString();
        }

        public static implicit operator Key(string str)
        {
            return new Key(str);
        }
    }
}

