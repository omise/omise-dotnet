using System;

namespace Omise
{
	public class ChargeService: ServiceBase
	{
		public ChargeService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public Charge CreateCharge(ChargeInfo charge)
		{
			if (!charge.Valid)
				throw new InvalidChargeException (getObjectErrors(charge)); 
			string result = requester.ExecuteRequest ("/charges", "POST", charge.ToRequestParams ());
			return chargeFactory.Create (result);
		}

		public Charge UpdateCharge(ChargeUpdateInfo charge){
			if (!charge.Valid)
				throw new ArgumentException ("Charge Id is required.");
			string result = requester.ExecuteRequest ("/charges/" + charge.Id, "PATCH", charge.ToRequestParams());
			return chargeFactory.Create (result);
		}

		public Charge GetCharge(string chargeId){
			return null;
		}

		public Charge Authorize (ChargeInfo charge)
		{
			return null;
		}

		public Charge Capture (ChargeInfo charge)
		{
			return null;
		}
	}
}

