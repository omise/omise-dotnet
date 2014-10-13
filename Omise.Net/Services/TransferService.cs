using System;
using System.Collections.Generic;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Transfer api
    /// </summary>
	public class TransferService: ServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.TransferService"/> class with api url and api key. The service uses default IRequestManager object.
		/// </summary>
		/// <param name="apiKey">API key</param>
		public TransferService (string apiKey): base(apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.TransferService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object</param>
		/// <param name="apiKey">API key</param>
		public TransferService (IRequestManager requestManager, string apiKey): base(requestManager, apiKey)
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
		public CollectionResponseObject<Transfer> GetAllTransfers(DateTime? from, DateTime? to, int? offset, int? limit){
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

			string url = "/transfers" + (parameters.Count > 0 ? "?" + string.Join ("&", parameters.ToArray ()) : "");
			string result = requester.ExecuteRequest (url, "GET", null);
			return transferFactory.CreateCollection (result);
		}

		/// <summary>
		/// Gets the transfer information.
		/// </summary>
		/// <returns>Omise Transfer object</returns>
		/// <param name="transferId">Transfer Id</param>
		public Transfer GetTransfer(string transferId){
			if (string.IsNullOrEmpty (transferId))
				throw new ArgumentNullException ("Transfer id is required");
			var result = requester.ExecuteRequest ("/transfers/" + transferId, "GET", null);
			return transferFactory.Create (result);
		}
	}
}

