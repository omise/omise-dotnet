using System;

namespace Omise
{
	public class TokenService: ServiceBase
	{
		public TokenService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public Token CreateToken(TokenInfo card){
			if (!card.Valid)
				throw new InvalidCardException (getObjectErrors(card));
			string result = requester.ExecuteRequest ("/tokens", "POST", card.ToRequestParams ());
			return tokenFactory.Create (result);
		}

		public Token GetToken(string tokenId){
			if (string.IsNullOrEmpty (tokenId))
				throw new ArgumentException ("Token id is required.");
			string result = requester.ExecuteRequest ("/tokens/" + tokenId, "GET", null);
			return tokenFactory.Create (result);
		}
	}
}

