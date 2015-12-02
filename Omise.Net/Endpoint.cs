namespace Omise.Net
{
    internal sealed partial class Endpoint
    {
        public static readonly Endpoint API = new Endpoint("https://api.omise.co", (creds) => creds.SecretKey);
        public static readonly Endpoint Vault = new Endpoint("https://vault.omise.co", (creds) => creds.PublicKey);

        public static Endpoint From(string value) {
            switch (value)
            {
                case "https://api.omise.co":
                    return API;
                case "https://vault.omise.co":
                    return Vault;
            }

            return null;
        }
    }

    internal sealed partial class Endpoint
    {
        private readonly OFunc<Credentials, Key> keySelector;

        public string Host { get; private set; }

        private Endpoint(string host, OFunc<Credentials, Key> keySelector)
        {
            this.Host = host;
            this.keySelector = keySelector;
        }

        public Key SelectKey(Credentials credentials)
        {
            return keySelector(credentials);
        }
    }
}

