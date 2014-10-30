using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// Defines all services to for requesting the api
    /// </summary>
    public class Client
    {
        private string privateKey;
        private string publicKey;
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
                    chargeService = new ChargeService(requestManager, privateKey);
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
                    cardService = new CardService(requestManager, privateKey, this.TokenService);
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
                    customerService = new CustomerService(requestManager, privateKey, this.TokenService);
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
                    accountService = new AccountService(requestManager, privateKey);
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
                    tokenService = new TokenService(requestManager, publicKey);
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
                    balanceService = new BalanceService(requestManager, privateKey);
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
                    transactionService = new TransactionService(requestManager, privateKey);
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
                    transferService = new TransferService(requestManager, privateKey);
                return transferService;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with Api keys. The client uses default IRequestManager object for all requests.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public Client(string apiKey)
        {
            this.privateKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with Api keys. The client uses default IRequestManager object for all requests.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public Client(string privateKey, string publicKey)
        {
            this.privateKey = privateKey;
            this.publicKey = publicKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="privateKey">Api key</param>
        public Client(IRequestManager requestManager, string privateKey)
        {
            this.requestManager = requestManager;
            this.privateKey = privateKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.Client"/> class with IRequestManager object and Api keys.
        /// </summary>
        /// <param name="requestManager"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        public Client(IRequestManager requestManager, string privateKey, string publicKey)
        {
            this.requestManager = requestManager;
            this.privateKey = privateKey;
            this.publicKey = publicKey;
        }
    }
}

