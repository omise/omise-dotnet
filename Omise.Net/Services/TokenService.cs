using System;

namespace Omise
{
	public class TokenService: ServiceBase
	{
		protected override string ApiUrlBase {
			get {
				return "https://vault.omise.co";
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.TokenService"/> class with api url and api key. The service uses default IRequestManager object.
		/// </summary>
		/// <param name="apiUrlBase">API base URL</param>
		/// <param name="apiKey">API key</param>
		public TokenService (string apiKey): base(apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.TokenService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object.</param>
		/// <param name="apiUrlBase">API base URL</param>
		/// <param name="apiKey">API key</param>
		public TokenService (IRequestManager requestManager, string apiKey): base(requestManager, apiKey)
		{
		}

		/// <summary>
		/// Creates the token to use for charging.
		/// </summary>
		/// <returns>Omise Token object</returns>
		/// <param name="token">TokenInfo object</param>
		public Token CreateToken(TokenInfo token){
			if (token == null)
				throw new ArgumentNullException ("Token info is required.");
			if (!token.Valid)
				throw new InvalidCardException (getObjectErrors(token));
			string result = requester.ExecuteRequest ("/tokens", "POST", token.ToRequestParams ());
			return tokenFactory.Create (result);
		}

		/// <summary>
		/// Gets the token information.
		/// </summary>
		/// <returns>Omise Token object</returns>
		/// <param name="tokenId">Token Id</param>
		public Token GetToken(string tokenId){
			if (string.IsNullOrEmpty (tokenId))
				throw new ArgumentNullException ("Token id is required.");
			string result = requester.ExecuteRequest ("/tokens/" + tokenId, "GET", null);
			return tokenFactory.Create (result);
		}
	}
}

