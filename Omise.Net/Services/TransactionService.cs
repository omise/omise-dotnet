using System;
using System.Collections.Generic;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Transaction api
    /// </summary>
    public class TransactionService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransactionService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public TransactionService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransactionService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public TransactionService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransactionService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public TransactionService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransactionService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public TransactionService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {
        }

        internal TransactionService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>CollectionResponseObject of transactions.</returns>
        /// <param name="from">Start date of transaction creation to scope the result</param>
        /// <param name="to">End date of transaction creation to scope the result</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit the numbers of return records</param>
        public CollectionResponseObject<Transaction> GetAllTransactions(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            var parameters = new List<string>();
            if (from.HasValue)
            {
                parameters.Add("from=" + DateTimeHelper.ToApiDateString(from.Value));
            }
            if (to.HasValue)
            {
                parameters.Add("to=" + DateTimeHelper.ToApiDateString(to.Value));
            }
            if (offset != null)
            {
                parameters.Add("offset=" + offset);
            }
            if (limit != null)
            {
                parameters.Add("limit=" + limit);
            }

            string url = "/transactions" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return transactionFactory.CreateCollection(result);
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>CollectionResponseObject of transactions.</returns>
        public CollectionResponseObject<Transaction> GetAllTransactions()
        {
            return GetAllTransactions(null, null, null, null);
        }

        /// <summary>
        /// Gets the transaction information.
        /// </summary>
        /// <returns>Omise transaction object</returns>
        /// <param name="transactionId">Transaction Id</param>
        public Transaction GetTransaction(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException("transactionId");
            string result = requester.ExecuteRequest("/transactions/" + transactionId, "GET", null);
            return transactionFactory.Create(result);
        }
    }
}

