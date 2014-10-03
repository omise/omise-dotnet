using System;

namespace Omise
{
	public abstract class ServiceBase
	{
		protected IRequestManager requester;
		protected AccountFactory accountFactory;
		protected BalanceFactory balanceFactory;
		protected CardFactory cardFactory;
		protected ChargeFactory chargeFactory;
		protected CustomerFactory customerFactory;
		protected TokenFactory tokenFactory;
		protected TransactionFactory transactionFactory;
		protected TransferFactory transferFactory;

		public ServiceBase (IRequestManager requestManager, string apiUrlBase, string apiKey)
		{
			if (requestManager == null) {
				requester = new RequestManager (apiUrlBase, apiKey);
			} else {
				requester = requestManager;
			}
			accountFactory = new AccountFactory();
			balanceFactory = new BalanceFactory();
			cardFactory = new CardFactory();
			chargeFactory = new ChargeFactory();
			customerFactory = new CustomerFactory();
			tokenFactory = new TokenFactory();
			transactionFactory = new TransactionFactory();
			transferFactory = new TransferFactory();
		}

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

