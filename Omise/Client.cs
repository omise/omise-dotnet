using System;
using Omise;
using Omise.Resources;

namespace Omise {
    public class Client {
        readonly Requester requester;

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
            requester = new Requester(credentials);

            Account = new AccountResource(requester);
            Balance = new BalanceResource(requester);
            Cards = new CardResourceShim(requester);
            Charges = new ChargeResource(requester);
            Customers = new CustomerResource(requester);
            Disputes = new DisputeResource(requester);
            Events = new EventResource(requester);
            Recipients = new RecipientResource(requester);
            Refunds = new RefundResourceShim(requester);
            Tokens = new TokenResource(requester);
            Transactions = new TransactionResource(requester);
            Transfers = new TransferResource(requester);
        }
    }
}