using System;
using Omise;
using Omise.Models;
using Omise.Resources;

namespace Omise {
    public class Client {
        IRequester Requester { get; set; }

        public readonly AccountResource Account;
        public readonly BalanceResource Balance;
        public readonly CardResourceShim Cards;
        public readonly ChargeResource Charges;
        public readonly CustomerResource Customers;
        public readonly DisputeResource Disputes;
        public readonly EventResource Events;
        public readonly RecipientResource Recipients;
        public readonly RefundResourceShim Refunds;
        public readonly TokenResource Tokens;
        public readonly TransactionResource Transactions;
        public readonly TransferResource Transfers;

        
        public Client(string pkey = null, string skey = null)
            : this(new Credentials(pkey, skey)) {
        }

        public Client(Credentials credentials) {
            if (credentials == null) throw new ArgumentNullException("credentials");

            Requester = new Requester(credentials);

            Account = new AccountResource(Requester);
            Balance = new BalanceResource(Requester);
            Cards = new CardResourceShim(Requester);
            Charges = new ChargeResource(Requester);
            Customers = new CustomerResource(Requester);
            Disputes = new DisputeResource(Requester);
            Events = new EventResource(Requester);
            Recipients = new RecipientResource(Requester);
            Refunds = new RefundResourceShim(Requester);
            Tokens = new TokenResource(Requester);
            Transactions = new TransactionResource(Requester);
            Transfers = new TransferResource(Requester);
        }
    }
}