using System;
using System.Collections.Generic;

namespace Omise
{
	public class TransferService: ServiceBase
	{
		public TransferService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public CollectionResponseObject<Transfer> GetAllTransfers(){
			return null;
		}

		public Transfer GetTransfer(string transferId){
			var result = requester.ExecuteRequest ("/transfers/" + transferId, "GET", null);
			return transferFactory.Create (result);
		}
	}
}

