using System;

namespace Omise
{
    /// <summary>
    /// Defines the base class containing factories for each models
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// IRequestManager object which is responsible for requesting the api
        /// </summary>
        protected IRequestManager requester;
        /// <summary>
        /// Account factory defines methods for creating Account object from api response
        /// </summary>
        protected AccountFactory accountFactory;

        /// <summary>
        /// Balance factory defines methods for creating Balance object from api response
        /// </summary>
        protected BalanceFactory balanceFactory;

        /// <summary>
        /// Card factory defines methods for creating Card object from api response
        /// </summary>
        protected CardFactory cardFactory;

        /// <summary>
        /// Charge factory defines methods for creating Charge object from api response
        /// </summary>
        protected ChargeFactory chargeFactory;

        /// <summary>
        /// Customer factory defines methods for creating Customer object from api response
        /// </summary>
        protected CustomerFactory customerFactory;

        /// <summary>
        /// Token factory defines methods for creating Token object from api response
        /// </summary>
        protected TokenFactory tokenFactory;

        /// <summary>
        /// Transaction factory defines methods for creating Transaction object from api response
        /// </summary>
        protected TransactionFactory transactionFactory;

        /// <summary>
        /// Transfer factory defines methods for creating Transfer object from api response
        /// </summary>
        protected TransferFactory transferFactory;

        /// <summary>
        /// The api base url for the service
        /// </summary>
        protected virtual string ApiUrlBase
        {
            //get { return "https://api.omise.co"; }
            get { return "http://api.lvh.me:3000"; }
        }

        /// <summary>
        /// Initializes the ServiceBase object
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public ServiceBase(IRequestManager requestManager, string apiKey)
        {
            if (requestManager == null)
            {
                requester = new RequestManager(ApiUrlBase, apiKey);
            }
            else
            {
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
        public ServiceBase(string apiKey)
        {
            requester = new RequestManager(ApiUrlBase, apiKey);
            accountFactory = new AccountFactory();
            balanceFactory = new BalanceFactory();
            cardFactory = new CardFactory();
            chargeFactory = new ChargeFactory();
            customerFactory = new CustomerFactory();
            tokenFactory = new TokenFactory();
            transferFactory = new TransferFactory();
        }

        /// <summary>
        /// Converts the error dictionary to a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getObjectErrors(IValidatable obj)
        {
            return DictionaryHelper.ToString(obj.Errors);
        }
    }
}

