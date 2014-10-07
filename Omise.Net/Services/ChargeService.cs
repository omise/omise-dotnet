using System;

namespace Omise
{
	public class ChargeService: ServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with api url and api key. The service uses default request manager object.
		/// </summary>
		/// <param name="apiUrlBase">API base URL</param>
		/// <param name="apiKey">API key</param>
		public ChargeService (string apiKey): base(apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object</param>
		/// <param name="apiUrlBase">API base URL</param>
		/// <param name="apiKey">API key</param>
		public ChargeService (IRequestManager requestManager, string apiKey): base(requestManager, apiKey)
		{
		}

		/// <summary>
		/// Creates a charge.
		/// </summary>
		/// <returns>The Omise charge object</returns>
		/// <param name="chargeInfo">ChargeInfo object</param>
		public Charge CreateCharge(ChargeCreateInfo chargeInfo)
		{
			if (chargeInfo == null)
				throw new ArgumentNullException ("Charge info is required.");
			if (!chargeInfo.Valid)
				throw new InvalidChargeException (getObjectErrors(chargeInfo)); 
			string result = requester.ExecuteRequest ("/charges", "POST", chargeInfo.ToRequestParams ());
			return chargeFactory.Create (result);
		}

		/// <summary>
		/// Updates a charge.
		/// </summary>
		/// <returns>The Omise charge object</returns>
		/// <param name="chargeUpdateInfo">Charge update info</param>
		public Charge UpdateCharge(ChargeUpdateInfo chargeUpdateInfo)
		{
			if (chargeUpdateInfo == null)
				throw new ArgumentNullException ("Charge update info is required.");
			if (!chargeUpdateInfo.Valid)
				throw new ArgumentException ("Charge Id is required.");
			string result = requester.ExecuteRequest ("/charges/" + chargeUpdateInfo.Id, "PATCH", chargeUpdateInfo.ToRequestParams());
			return chargeFactory.Create (result);
		}

		/// <summary>
		/// Gets the charge.
		/// </summary>
		/// <returns>The Omise charge object</returns>
		/// <param name="chargeId">Charge Id</param>
		public Charge GetCharge(string chargeId){
			if (string.IsNullOrEmpty (chargeId))
				throw new ArgumentNullException ("chargeId is required.");

			string url = string.Format ("/charges/{0}", chargeId);
			string result = requester.ExecuteRequest (url, "GET", null);
			return chargeFactory.Create (result);
		}
	}
}

