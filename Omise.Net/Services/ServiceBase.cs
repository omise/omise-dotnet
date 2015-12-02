using System;
using System.Collections.Generic;
using Omise.Net;

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
        /// BankAccount factory defines methods for creating BankAccount object from api response
        /// </summary>
        protected BankAccountFactory bankAccountFactory;

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
        /// Recipient factory defines methods for creating Recipient object from api response
        /// </summary>
        protected RecipientFactory recipientFactory;

        /// <summary>
        /// Refund factory defines methods for creating Refund object from api response
        /// </summary>
        protected RefundFactory refundFactory;

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
        /// Dispute factory defines methods for creating Dispute object from api response
        /// </summary>
        protected DisputeFactory disputeFactory;

        /// <summary>
        /// The endpoint to use for the service.
        /// </summary>
        /// <value>The endpoint.</value>
        internal virtual Endpoint Endpoint
        {
            get { return Endpoint.API; }
        }

        private void init()
        {
            accountFactory = new AccountFactory();
            balanceFactory = new BalanceFactory();
            bankAccountFactory = new BankAccountFactory();
            cardFactory = new CardFactory();
            chargeFactory = new ChargeFactory();
            customerFactory = new CustomerFactory();
            recipientFactory = new RecipientFactory();
            refundFactory = new RefundFactory();
            tokenFactory = new TokenFactory();
            transactionFactory = new TransactionFactory();
            transferFactory = new TransferFactory();
            disputeFactory = new DisputeFactory();
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
                requester = new RequestManager(Endpoint, new Credentials(null, apiKey), null);
            }
            else
            {
                requester = requestManager;
            }

            init();
        }

        /// <summary>
        /// Initializes the ServiceBase object
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public ServiceBase(string apiKey)
        {
            requester = new RequestManager(Endpoint, new Credentials(null, apiKey), null);
            init();
        }

        public ServiceBase(string apiKey, string apiVersion)
        {
            requester = new RequestManager(Endpoint, new Credentials(null, apiKey), apiVersion);
            init();
        }

        public ServiceBase(IRequestManager requestManager, string apiKey, string apiVersion)
        {
            if (requestManager == null)
            {
                requester = new RequestManager(Endpoint, new Credentials(null, apiKey), apiVersion);
            }
            else
            {
                requester = requestManager;
            }

            init();
        }

        internal ServiceBase(IRequestManager requestManager, Credentials credentials, string apiVersion)
        {
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            if (requestManager == null)
            {
                requestManager = new RequestManager(Endpoint, credentials, apiVersion);
            }

            requester = requestManager;
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

        protected List<string> BuildPaginationParams(DateTime? from, DateTime? to, int? offset, int? limit)
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
            if (offset.HasValue)
            {
                parameters.Add("offset=" + offset.Value);
            }
            if (limit.HasValue)
            {
                parameters.Add("limit=" + limit.Value);
            }

            return parameters;
        }
    }
}

