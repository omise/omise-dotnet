using System;
using System.Collections.Generic;

namespace Omise
{
    public class CustomEnvironment : IEnvironment
    {
        readonly IDictionary<Endpoint, string> endpointMappings;

        public CustomEnvironment(IDictionary<Endpoint, string> endpointMappings)
        {
            if (endpointMappings == null) throw new ArgumentNullException(nameof(endpointMappings));

            this.endpointMappings = endpointMappings;
        }

        public string ResolveEndpoint(Endpoint endpoint)
        {
            if (!endpointMappings.ContainsKey(endpoint)) throw new ArgumentOutOfRangeException(nameof(endpoint));

            return endpointMappings[endpoint];
        }

        public Key SelectKey(Endpoint endpoint, Credentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));

            switch (endpoint)
            {
                case Endpoint.Vault: return credentials.PublicKey;
                case Endpoint.Api: return credentials.SecretKey;
                default: throw new ArgumentOutOfRangeException(nameof(endpoint));
            }
        }
    }
}
