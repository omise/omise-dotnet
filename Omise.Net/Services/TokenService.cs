using System;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Token api
    /// </summary>
    public class TokenService : ServiceBase
    {
        /// <summary>
        /// Api base url
        /// </summary>
        protected override string ApiUrlBase
        {
            get
            {
                return "http://vault.lvh.me:3000";
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">API key</param>
        public TokenService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TokenService"/> class with IRequestManager object and api key.
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">API key</param>
        public TokenService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
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

