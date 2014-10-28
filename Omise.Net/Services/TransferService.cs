using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Transfer api
    /// </summary>
    public class TransferService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with api key. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">API key</param>
        public TransferService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.TransferService"/> class with IRequestManager object and api key.
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">API key</param>
        public TransferService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
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

		public CollectionResponseObject<Transfer> GetAllTransfers(){
			return GetAllTransfers (null, null, null, null);
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
        public Transfer CreateTransfer(int amount) {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.");
            string result = requester.ExecuteRequest("/transfers", "POST", "amount=" + amount.ToString());
            return transferFactory.Create(result);
        }

        /// <summary>
        /// Create a transfer request with full available balance amount
        /// </summary>
        /// <returns></returns>
        public Transfer CreateTransfer() {
            string result = requester.ExecuteRequest("/transfers", "POST", null);
            return transferFactory.Create(result);
        }
    }
}

