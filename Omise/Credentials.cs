using System;

namespace Omise
{
    public delegate Key KeySelector(Credentials creds);

    public sealed partial class Credentials
    {
        public static readonly KeySelector UsePublicKey = new KeySelector(creds => creds.PublicKey);
        public static readonly KeySelector UseSecretKey = new KeySelector(creds => creds.SecretKey);
    }

    public sealed partial class Credentials
    {
        public Key PublicKey { get; private set; }
        public Key SecretKey { get; private set; }

        public Credentials(string pkey = null, string skey = null)
        {
            if (string.IsNullOrEmpty(pkey) && string.IsNullOrEmpty(skey))
            {
                throw new ArgumentException("pkey and skey can't both be null");
            }

            PublicKey = pkey;
            SecretKey = skey;
        }
    }
}