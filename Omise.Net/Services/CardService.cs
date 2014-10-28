using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting Card api
    /// </summary>
    public class CardService : ServiceBase
    {
        private TokenService tokenService;
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CardService"/> class with api key and TokenService object. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">API key</param>
        public CardService(string apiKey, TokenService tokenService)
            : base(apiKey)
        {
            if (tokenService == null)
				throw new ArgumentNullException("tokenService");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CardService"/> class with IRequestManager object, api key and TokenService object.
        /// </summary>
        /// <param name="requestManager">Request manager.</param>
        /// <param name="apiKey">API key.</param>
        public CardService(IRequestManager requestManager, string apiKey, TokenService tokenService)
            : base(requestManager, apiKey)
        {
            if (tokenService == null)
				throw new ArgumentNullException("tokenService");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Creates the credit card.
        /// </summary>
        /// <returns>The created Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardCreateInfo">CardInfo object</param>
        public Card CreateCard(string customerId, CardCreateInfo cardCreateInfo)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            if (cardCreateInfo == null)
				throw new ArgumentNullException("cardCreateInfo");
            if (!cardCreateInfo.Valid)
                throw new InvalidCardException(getObjectErrors(cardCreateInfo));

            var tokenResult = this.tokenService.CreateToken(new TokenInfo()
            {
                Card = cardCreateInfo
            });

            string url = string.Format("/customers/{0}/cards", customerId);
            string result = requester.ExecuteRequest(url, "POST", string.Format("card={0}", tokenResult.Id));
            return cardFactory.Create(result);
        }

        /// <summary>
        /// Creates the credit card with customer id and card token
        /// </summary>
        /// <param name="customerId">Customer's Id</param>
        /// <param name="cardToken">Card token</param>
        /// <returns>Omise Card object</returns>
        public Card CreateCard(string customerId, string cardToken)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            if (string.IsNullOrEmpty(cardToken))
				throw new ArgumentNullException("cardToken");
            string url = string.Format("/customers/{0}/cards", customerId);
            string result = requester.ExecuteRequest(url, "POST", string.Format("card={0}", cardToken));
            return cardFactory.Create(result);
        }

        /// <summary>
        /// Updates the credit card.
        /// </summary>
        /// <returns>The updated Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardInfo">CardInfo object</param>
        public Card UpdateCard(string customerId, CardUpdateInfo cardUpdateInfo)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            if (cardUpdateInfo == null)
				throw new ArgumentNullException("cardUpdateInfo");
            if (!cardUpdateInfo.Valid)
                throw new InvalidCardException(getObjectErrors(cardUpdateInfo));
            string url = string.Format("/customers/{0}/cards/{1}", customerId, cardUpdateInfo.Id);
            string result = requester.ExecuteRequest(url, "PATCH", cardUpdateInfo.ToRequestParams());
            return cardFactory.Create(result);
        }

        /// <summary>
        /// Gets all cards belongs to a customer.
        /// </summary>
        /// <returns>CollectionResponseObject of cards</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="from">Start date of card creation to scope the result</param>
        /// <param name="to">End date of card creation to scope the result</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit the numbers of return records</param>
        public CollectionResponseObject<Card> GetAllCards(string customerId, DateTime? from, DateTime? to, int? offset, int? limit)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            var parameters = new List<string>();
            if (from.HasValue)
            {
                parameters.Add("from=" + DateTimeHelper.ToApiDateString(from.Value));
            }
            if (to.HasValue)
            {
                parameters.Add("to=" + DateTimeHelper.ToApiDateString(to.Value));
            }
            if (offset.HasValue)
            {
                parameters.Add("offset=" + offset.Value);
            }
            if (limit.HasValue)
            {
                parameters.Add("limit=" + limit.Value);
            }

            string url = string.Format("/customers/{0}/cards" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : ""), customerId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return cardFactory.CreateCollection(result);
        }

		public CollectionResponseObject<Card> GetAllCards(string customerId){
			return GetAllCards (customerId, null, null, null, null);
		}

        /// <summary>
        /// Gets the Omise card information.
        /// </summary>
        /// <returns>The Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardId">Card Id</param>
        public Card GetCard(string customerId, string cardId)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            if (string.IsNullOrEmpty(cardId))
				throw new ArgumentNullException("cardId");
            string url = string.Format("/customers/{0}/cards/{1}", customerId, cardId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return cardFactory.Create(result);
        }

        /// <summary>
        /// Deletes the Omise card.
        /// </summary>
        /// <returns>The result of deleting the object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardId">Card Id</param>
        public DeleteResponseObject DeleteCard(string customerId, string cardId)
        {
            if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException("customerId");
            if (string.IsNullOrEmpty(cardId))
				throw new ArgumentNullException("cardId");
            string url = string.Format("/customers/{0}/cards/{1}", customerId, cardId);
            string result = requester.ExecuteRequest(url, "DELETE", null);
            return JsonConvert.DeserializeObject<DeleteResponseObject>(result);
        }
    }
}

