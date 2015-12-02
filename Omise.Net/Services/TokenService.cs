using System;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Token api
    /// </summary>
    public class TokenService : ServiceBase
    {
        internal override Endpoint Endpoint
        {
            get
            {
                return Endpoint.Vault;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public TokenService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public TokenService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        public TokenService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public TokenService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {
        }

        internal TokenService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }

        /// <summary>
        /// Creates the token to use for charging.
        /// </summary>
        /// <returns>Omise Token object</returns>
        /// <param name="token">TokenInfo object</param>
        public Token CreateToken(TokenInfo tokenInfo)
        {
            if (tokenInfo == null)
                throw new ArgumentNullException("tokenInfo");
            if (!tokenInfo.Valid)
                throw new InvalidCardException(getObjectErrors(tokenInfo));
            string result = requester.ExecuteRequest("/tokens", "POST", tokenInfo.ToRequestParams());
            return tokenFactory.Create(result);
        }

        /// <summary>
        /// Gets the token information.
        /// </summary>
        /// <returns>Omise Token object</returns>
        /// <param name="tokenId">Token Id</param>
        public Token GetToken(string tokenId)
        {
            if (string.IsNullOrEmpty(tokenId))
                throw new ArgumentNullException("tokenId");
            string result = requester.ExecuteRequest("/tokens/" + tokenId, "GET", null);
            return tokenFactory.Create(result);
        }
    }
}

