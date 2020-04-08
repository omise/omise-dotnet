using System;
using Omise.Resources;
using Omise.Models;

namespace Omise
{
    public class Client
    {
        // Default to the latest API Version.
        public readonly string APIVersion = "2019-05-29";

        readonly IRequester requester;
        readonly IEnvironment environment;

        public readonly AccountResource Account;
        public readonly BalanceResource Balance;
        public readonly ChargeResource Charges;
        public readonly CustomerResource Customers;
        public readonly DisputeResource Disputes;
        public readonly EventResource Events;
        public readonly ForexResource Forex;
        public readonly LinkResource Links;
        public readonly OccurrenceResource Occurrences;
        public readonly SourceResource Sources;
        public readonly ReceiptResource Receipts;
        public readonly RecipientResource Recipients;
        public readonly RefundResource Refunds;
        public readonly ScheduleResource Schedules;
        public readonly TokenResource Tokens;
        public readonly TransactionResource Transactions;
        public readonly TransferResource Transfers;

        public IRequester Requester
        {
            get { return requester; }
        }

        public IEnvironment Environment
        {
            get { return environment; }
        }

        public Client(string pkey = null, string skey = null, IEnvironment env = null)
            : this(new Credentials(pkey, skey), env)
        {
        }

        public Client(Credentials credentials, IEnvironment env = null)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));

            environment = env ?? Environments.Production;
            requester = new Requester(credentials, environment, null, APIVersion);

            Account = new AccountResource(requester);
            Balance = new BalanceResource(requester);
            Charges = new ChargeResource(requester);
            Customers = new CustomerResource(requester);
            Disputes = new DisputeResource(requester);
            Events = new EventResource(requester);
            Forex = new ForexResource(requester);
            Links = new LinkResource(requester);
            Occurrences = new OccurrenceResource(requester);
            Sources = new SourceResource(requester);
            Receipts = new ReceiptResource(requester);
            Recipients = new RecipientResource(requester);
            Refunds = new RefundResource(requester);
            Schedules = new ScheduleResource(requester);
            Tokens = new TokenResource(requester);
            Transactions = new TransactionResource(requester);
            Transfers = new TransferResource(requester);
        }
    }
}