using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Transfer api
    /// </summary>
    public class TransferService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public TransferService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public TransferService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with Api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public TransferService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public TransferService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {
        }

        internal TransferService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }

        /// <summary>
        /// Gets all transfers.
        /// </summary>
        /// <returns>CollectionResponseObject of transfers.</returns>
        /// <param name="from">Start date of transfer creation to scope the result</param>
        /// <param name="to">End date of transfer creation to scope the result</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit the numbers of return records</param>
        public CollectionResponseObject<Transfer> GetAllTransfers(DateTime? from, DateTime? to, int? offset, int? limit)
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

            string url = "/transfers" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return transferFactory.CreateCollection(result);
        }

        /// <summary>
        /// Gets all transfers.
        /// </summary>
        /// <returns>CollectionResponseObject of transfers.</returns>
        public CollectionResponseObject<Transfer> GetAllTransfers()
        {
            return GetAllTransfers(null, null, null, null);
        }

        /// <summary>
        /// Gets the transfer information.
        /// </summary>
        /// <returns>Omise Transfer object</returns>
        /// <param name="transferId">Transfer Id</param>
        public Transfer GetTransfer(string transferId)
        {
            if (string.IsNullOrEmpty(transferId))
                throw new ArgumentNullException("transferId");
            string result = requester.ExecuteRequest("/transfers/" + transferId, "GET", null);
            return transferFactory.Create(result);
        }

        /// <summary>
        /// Create a transfer request with amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Transfer CreateTransfer(int amount, string recipientId = "")
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.");

            var parameters = "amount=" + amount.ToString();
            if (!string.IsNullOrEmpty(recipientId))
            {
                parameters += "&recipient=" + recipientId;
            }

            string result = requester.ExecuteRequest("/transfers", "POST", parameters);
            return transferFactory.Create(result);
        }

        /// <summary>
        /// Updates the transfer.
        /// </summary>
        /// <returns>The transfer.</returns>
        /// <param name="transferId">Transfer id</param>
        /// <param name="amount">Amount</param>
        public Transfer UpdateTransfer(string transferId, int amount)
        {
            if (string.IsNullOrEmpty(transferId))
                throw new ArgumentNullException("transferId");
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.");
            string result = requester.ExecuteRequest("/transfers/" + transferId, "PATCH", "amount=" + amount.ToString());
            return transferFactory.Create(result);
        }

        /// <summary>
        /// Deletes the transfer.
        /// </summary>
        /// <returns>The result of deleting the object</returns>
        /// <param name="transferId">Transfer id</param>
        public Transfer DeleteTransfer(string transferId)
        {
            if (string.IsNullOrEmpty(transferId))
                throw new ArgumentNullException("transferId");
            string result = requester.ExecuteRequest("/transfers/" + transferId, "DELETE", null);
            return transferFactory.Create(result);
        }

        /// <summary>
        /// Create a transfer request with full available balance amount
        /// </summary>
        /// <returns></returns>
        public Transfer CreateTransfer(string recipientId = "")
        {
            var parameters = string.IsNullOrEmpty(recipientId) ? null : "recipient=" + recipientId;

            string result = requester.ExecuteRequest("/transfers", "POST", parameters);
            return transferFactory.Create(result);
        }
    }
}

