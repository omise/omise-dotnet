using System;

namespace Omise
{
	public abstract class ServiceBase
	{
		protected RequestManager requester;
		protected AccountFactory accountFactory;
		protected BalanceFactory balanceFactory;
		protected CardFactory cardFactory;
		protected ChargeFactory chargeFactory;
		protected CustomerFactory customerFactory;
		protected TokenFactory tokenFactory;
		protected TransferFactory transferFactory;

		public ServiceBase (string apiUrlBase, string apiKey)
		{
			requester = new RequestManager (apiUrlBase, apiKey);
			accountFactory = new AccountFactory();
			balanceFactory = new BalanceFactory();
			cardFactory = new CardFactory();
			chargeFactory = new ChargeFactory();
			customerFactory = new CustomerFactory();
			tokenFactory = new TokenFactory();
			transferFactory = new TransferFactory ();
		}

		protected string getObjectErrors(IValidatable obj)
		{
			return DictionaryHelper.ToString (obj.Errors);
		}
	}
}

