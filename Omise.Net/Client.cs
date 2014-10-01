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

		private ChargeService chargeService;
		public ChargeService ChargeService{ 
			get{ 
				if (chargeService == null)
					chargeService = new ChargeService (apiUrlBase, apiKey);
				return chargeService;
			}
		}

		private CardService cardService;
		public CardService CardService{ 
			get{ 
				if (cardService == null)
					cardService = new CardService (apiUrlBase, apiKey);
				return cardService;
			}
		}

		private CustomerService customerService;
		public CustomerService CustomerService {
			get {
				if (customerService == null)
					customerService = new CustomerService (apiUrlBase, apiKey);
				return customerService;
			}
		}

		private AccountService accountService;
		public AccountService AccountService{ 
			get{ 
				if (accountService == null)
					accountService = new AccountService (apiUrlBase, apiKey);
				return accountService;
			}
		}

		private TokenService tokenService;
		public TokenService TokenService{
			get{ 
				if (tokenService == null)
					tokenService = new TokenService (apiUrlBase, apiKey);
				return tokenService;
			}
		}

		private BalanceService balanceService;
		public BalanceService BalanceService{
			get{ 
				if (balanceService == null)
					balanceService = new BalanceService (apiUrlBase, apiKey);
				return balanceService;
			}
		}

		public Client(string apiKey, string apiUrlBase)
		{
			this.apiKey = apiKey;
			this.apiUrlBase = apiUrlBase;
		}
	}
}

