using System;

namespace Omise
{
    /// <summary>
    /// Defines the base class containing factories for each models
    /// </summary>
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

        /// <summary>
        /// The api base url for the service
        /// </summary>
		protected virtual string ApiUrlBase
		{
            get { return "https://api.omise.co"; }
		}

        /// <summary>
        /// Initializes the ServiceBase object
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
		public ServiceBase (IRequestManager requestManager, string apiKey)
		{
			if (requestManager == null) {
				requester = new RequestManager (ApiUrlBase, apiKey);
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

        /// <summary>
        /// Initializes the ServiceBase object
        /// </summary>
        /// <param name="apiKey">Api key</param>
		public ServiceBase (string apiKey)
		{
			requester = new RequestManager (ApiUrlBase, apiKey);
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

