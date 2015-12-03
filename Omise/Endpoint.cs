using System;

namespace Omise {
    public sealed class Endpoint {
        public string ApiPrefix { get; private set; }
        public KeySelector KeySelector { get; private set; }

        public Endpoint(string apiPrefix, KeySelector keySelector = null) {
            if (string.IsNullOrEmpty(apiPrefix)) throw new ArgumentNullException("apiPrefix");
            if (keySelector == null) keySelector = Credentials.UseSecretKey;

            ApiPrefix = apiPrefix;
            KeySelector = keySelector;
        }
    }
}

