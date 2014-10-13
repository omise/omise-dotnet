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
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CardService"/> class with api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">API key</param>
        public CardService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CardService"/> class with IRequestManager object and api key.
        /// </summary>
        /// <param name="requestManager">Request manager.</param>
        /// <param name="apiKey">API key.</param>
        public CardService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Creates the credit card.
        /// </summary>
        /// <returns>The created Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardInfo">CardInfo object</param>
        public Card CreateCard(string customerId, CardCreateInfo cardInfo)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId is required.");
            if (cardInfo == null)
                throw new ArgumentNullException("card is required.");
            if (!cardInfo.Valid)
                throw new InvalidCardException(getObjectErrors(cardInfo));
            string url = string.Format("/customers/{0}/cards", customerId);
            string result = requester.ExecuteRequest(url, "POST", cardInfo.ToRequestParams());
            return cardFactory.Create(result);
        }

        /// <summary>
        /// Updates the credit card.
        /// </summary>
        /// <returns>The updated Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardInfo">CardInfo object</param>
        public Card UpdateCard(string customerId, CardCreateInfo cardInfo)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId is required.");
            if (cardInfo == null)
                throw new ArgumentNullException("card is required.");
            if (!cardInfo.Valid)
                throw new InvalidCardException(getObjectErrors(cardInfo));
            string url = string.Format("/customers/{0}/cards/{1}", customerId, cardInfo.Id);
            string result = requester.ExecuteRequest(url, "PATCH", cardInfo.ToRequestParams());
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
                throw new ArgumentNullException("customerId is required.");
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

        /// <summary>
        /// Gets the Omise card information.
        /// </summary>
        /// <returns>The Omise card object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardId">Card Id</param>
        public Card GetCard(string customerId, string cardId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId is required.");
            if (string.IsNullOrEmpty(cardId))
                throw new ArgumentNullException("cardId is required.");
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
                throw new ArgumentNullException("customerId is required.");
            if (string.IsNullOrEmpty(cardId))
                throw new ArgumentNullException("cardId is required.");
            string url = string.Format("/customers/{0}/cards/{1}", customerId, cardId);
            var result = requester.ExecuteRequest(url, "DELETE", null);
            return JsonConvert.DeserializeObject<DeleteResponseObject>(result);
        }
    }
}

