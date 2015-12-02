using System;
using System.Net;
using System.IO;
using System.Text;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// Defines all services to for requesting the api
    /// </summary>
    public class Client
    {
        private Credentials credentials;
        private IRequestManager requestManager;

        private ChargeService chargeService;

        /// <summary>
        /// Gets the charge service.
        /// </summary>
        /// <value>The charge service.</value>
        public ChargeService ChargeService
        {
            get
            {
                if (chargeService == null)
                    chargeService = new ChargeService(requestManager, credentials, ApiVersion);
                return chargeService;
            }
        }

        private CardService cardService;

        /// <summary>
        /// Gets the card service.
        /// </summary>
        /// <value>The card service.</value>
        public CardService CardService
        {
            get
            {
                if (cardService == null)
                    cardService = new CardService(requestManager, credentials, this.TokenService, ApiVersion);
                return cardService;
            }
        }

        private CustomerService customerService;

        /// <summary>
        /// Gets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        public CustomerService CustomerService
        {
            get
            {
                if (customerService == null)
                    customerService = new CustomerService(requestManager, credentials, this.TokenService, ApiVersion);
                return customerService;
            }
        }

        private AccountService accountService;

        /// <summary>
        /// Gets the account service.
        /// </summary>
        /// <value>The account service.</value>
        public AccountService AccountService
        {
            get
            {
                if (accountService == null)
                    accountService = new AccountService(requestManager, credentials, ApiVersion);
                return accountService;
            }
        }

        private TokenService tokenService;

        /// <summary>
        /// Gets the token service.
        /// </summary>
        /// <value>The token service.</value>
        public TokenService TokenService
        {
            get
            {
                if (tokenService == null)
                    tokenService = new TokenService(requestManager, credentials, ApiVersion);
                return tokenService;
            }
        }

        private BalanceService balanceService;

        /// <summary>
        /// Gets the balance service.
        /// </summary>
        /// <value>The balance service.</value>
        public BalanceService BalanceService
        {
            get
            {
                if (balanceService == null)
                    balanceService = new BalanceService(requestManager, credentials, ApiVersion);
                return balanceService;
            }
        }

        private TransactionService transactionService;

        /// <summary>
        /// Gets the transaction service.
        /// </summary>
        /// <value>The transaction service.</value>
        public TransactionService TransactionService
        {
            get
            {
                if (transactionService == null)
                    transactionService = new TransactionService(requestManager, credentials, ApiVersion);
                return transactionService;
            }
        }

        private TransferService transferService;

        /// <summary>
        /// Gets the transfer service.
        /// </summary>
        /// <value>The transfer service.</value>
        public TransferService TransferService
        {
            get
            {
                if (transferService == null)
                    transferService = new TransferService(requestManager, credentials, ApiVersion);
                return transferService;
            }
        }

        private RecipientService recipientService;

        public RecipientService RecipientService
        {
            get
            { 
                if (recipientService == null)
                    recipientService = new RecipientService(requestManager, credentials, ApiVersion);
                return recipientService;
            }
        }

        private DisputeService disputeService;

        public DisputeService DisputeService
        {
            get
            {
                if (disputeService == null)
                    disputeService = new DisputeService(requestManager, credentials, ApiVersion);
                
                return disputeService;
            }
        }

        public string ApiVersion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with Api keys. The client uses default IRequestManager object for all requests.
        /// </summary>
        /// <param name="secretKey">Secret key</param>
        public Client(string secretKey)
        {
            this.credentials = new Credentials(null, secretKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with Api keys. The client uses default IRequestManager object for all requests.
        /// </summary>
        /// <param name="secretKey">Secret key</param>
        public Client(string secretKey, string publicKey)
        {
            this.credentials = new Credentials(publicKey, secretKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="secretKey">Secret key</param>
        public Client(IRequestManager requestManager, string secretKey)
        {
            this.requestManager = requestManager;
            this.credentials = new Credentials(null, secretKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with IRequestManager object and Api keys.
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="secretKey">Secret key</param>
        /// <param name="publicKey">Public key</param>
        public Client(IRequestManager requestManager, string secretKey, string publicKey)
        {
            this.requestManager = requestManager;
            this.credentials = new Credentials(publicKey, secretKey);
        }
    }
}

