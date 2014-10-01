using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Omise
{
	public class CardService: ServiceBase
	{
		public CardService (string apiUrlBase, string apiKey) : base (apiUrlBase, apiKey)
		{
		}

		public Card CreateCard (string customerId, CardInfo card)
		{
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required.");
			
			if (!card.Valid)
				throw new InvalidCardException (getObjectErrors (card)); 
			string url = string.Format ("/customers/{0}/cards", customerId);
			string result = requester.ExecuteRequest (url, "POST", card.ToRequestParams ());
			return cardFactory.Create (result);
		}

		public CollectionResponseObject<Card> GetAllCards (string customerId, DateTime? from, DateTime? to, int? offset, int? limit)
		{
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required.");
			var parameters = new List<string> ();
			if (from.HasValue) {
				parameters.Add ("from=" + DateTimeHelper.ToApiDateString(from.Value));
			}
			if (to.HasValue) {
				parameters.Add ("to=" + DateTimeHelper.ToApiDateString(to.Value));
			}
			if (offset != null) {
				parameters.Add ("offset=" + offset);
			}
			if (limit != null) {
				parameters.Add ("limit=" + limit);
			}

			string url = string.Format ("/customers/{0}/cards" + (parameters.Count > 0 ? "?" + string.Join ("&", parameters.ToArray ()) : ""), customerId);
			string result = requester.ExecuteRequest (url, "GET", null);
			return cardFactory.CreateCollection (result);
		}

		public Card GetCard (string customerId, string cardId)
		{
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required.");
			if (string.IsNullOrEmpty (cardId))
				throw new ArgumentException ("cardId is required.");
			string url = string.Format ("/customers/{0}/cards/{1}", customerId, cardId);
			string result = requester.ExecuteRequest (url, "GET", null);
			return cardFactory.Create (result);
		}

		public void DeleteCard (string customerId, string cardId)
		{
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required.");
			if (string.IsNullOrEmpty (cardId))
				throw new ArgumentException ("cardId is required.");
			string url = string.Format ("/customers/{0}/cards/{1}", customerId, cardId);
			requester.ExecuteRequest (url, "DELETE", null);
		}
	}
}

