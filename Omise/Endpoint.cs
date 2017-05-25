using System;

namespace Omise
{
    public sealed partial class Endpoint
    {
        public static readonly Endpoint Api = new Endpoint("https://api.omise.co", Credentials.UseSecretKey);
        public static readonly Endpoint Vault = new Endpoint("https://vault.omise.co", Credentials.UsePublicKey);
    }

    public sealed partial class Endpoint
    {
        public string ApiPrefix { get; private set; }
        public KeySelector KeySelector { get; private set; }

        public Endpoint(string apiPrefix, KeySelector keySelector = null)
        {
            if (string.IsNullOrEmpty(apiPrefix)) throw new ArgumentNullException(nameof(apiPrefix));
            if (keySelector == null) keySelector = Credentials.UseSecretKey;

            ApiPrefix = apiPrefix;
            KeySelector = keySelector;
        }
    }
}