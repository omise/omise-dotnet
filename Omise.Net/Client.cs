using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
	public class Client
	{
		private string apiKey;
		private string apiUrlBase;
		private IRequestManager requestManager;

		private ChargeService chargeService;
		/// <summary>
		/// Gets the charge service.
		/// </summary>
		/// <value>The charge service.</value>
		public ChargeService ChargeService{ 
			get{ 
				if (chargeService == null)
					chargeService = new ChargeService (requestManager, apiKey);
				return chargeService;
			}
		}

		private CardService cardService;
		/// <summary>
		/// Gets the card service.
		/// </summary>
		/// <value>The card service.</value>
		public CardService CardService{ 
			get{ 
				if (cardService == null)
					cardService = new CardService (requestManager, apiKey);
				return cardService;
			}
		}

		private CustomerService customerService;
		/// <summary>
		/// Gets the customer service.
		/// </summary>
		/// <value>The customer service.</value>
		public CustomerService CustomerService {
			get {
				if (customerService == null)
					customerService = new CustomerService (requestManager, apiKey);
				return customerService;
			}
		}

		private AccountService accountService;
		/// <summary>
		/// Gets the account service.
		/// </summary>
		/// <value>The account service.</value>
		public AccountService AccountService{ 
			get{ 
				if (accountService == null)
					accountService = new AccountService (requestManager, apiKey);
				return accountService;
			}
		}

		private TokenService tokenService;
		/// <summary>
		/// Gets the token service.
		/// </summary>
		/// <value>The token service.</value>
		public TokenService TokenService{
			get{ 
				if (tokenService == null)
					tokenService = new TokenService (requestManager, apiKey);
				return tokenService;
			}
		}

		private BalanceService balanceService;
		/// <summary>
		/// Gets the balance service.
		/// </summary>
		/// <value>The balance service.</value>
		public BalanceService BalanceService{
			get{ 
				if (balanceService == null)
					balanceService = new BalanceService (requestManager, apiKey);
				return balanceService;
			}
		}

		private TransactionService transactionService;
		/// <summary>
		/// Gets the transaction service.
		/// </summary>
		/// <value>The transaction service.</value>
		public TransactionService TransactionService{
			get{ 
				if (transactionService == null)
					transactionService = new TransactionService (requestManager, apiKey);
				return transactionService;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.Client"/> class with api key and api url. The client uses default IRequestManager object for all requests.
		/// </summary>
		/// <param name="apiKey">API key.</param>
		/// <param name="apiUrlBase">API base URL.</param>
		public Client(string apiKey)
		{
			this.apiKey = apiKey;
			this.apiUrlBase = apiUrlBase;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.Client"/> class with IRequestManager object, api key and api url.
		/// </summary>
		/// <param name="requestManager">IRequestManager object</param>
		/// <param name="apiKey">API key</param>
		/// <param name="apiUrlBase">API base URL</param>
		public Client(IRequestManager requestManager, string apiKey)
		{
			this.requestManager = requestManager;
			this.apiKey = apiKey;
			this.apiUrlBase = apiUrlBase;
		}
	}
}

