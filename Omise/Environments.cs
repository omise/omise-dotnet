using System;
using System.Collections.Generic;

namespace Omise
{
    public sealed class Environments
    {
        public static readonly IEnvironment Production =
            new CustomEnvironment(new Dictionary<Endpoint, string> {
                { Endpoint.Api, "https://api.omise.co" },
                { Endpoint.Vault, "https://vault.omise.co" },
            });

        public static readonly IEnvironment Staging =
            new CustomEnvironment(new Dictionary<Endpoint, string> {
                { Endpoint.Api, "https://api-staging.omise.co" },
                { Endpoint.Vault, "https://vault-staging.omise.co" },
            });

        public static readonly IEnvironment LocalMachine =
            new CustomEnvironment(new Dictionary<Endpoint, string> {
                { Endpoint.Api, "https://api.lvh.me:3000" },
                { Endpoint.Vault, "https://vault.lvh.me:4500" },
            });
    }
}
