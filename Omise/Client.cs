using System;
using Omise.Resources;
using Omise.Models;

namespace Omise
{
    public class Client
    {
        // Default to the latest API Version.
        private string apiVersion = "2019-05-29";

        readonly IRequester requester;
        readonly IEnvironment environment;

        public readonly AccountResource Account;
        public readonly BalanceResource Balance;
        public readonly CapabilityResource Capability;
        public readonly ChargeResource Charges;
        public readonly CustomerResource Customers;
        public readonly DisputeResource Disputes;
        public readonly EventResource Events;
        public readonly ForexResource Forex;
        public readonly LinkResource Links;
        public readonly OccurrenceResource Occurrences;
        public readonly PaymentSourceResource Sources;
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

        public string APIVersion
        {
            get { return requester.APIVersion; }
            set { requester.APIVersion = value; }
        }

        public Client(string pkey = null, string skey = null, IEnvironment env = null)
            : this(new Credentials(pkey, skey), env)
        {
        }

        public Client(Credentials credentials, IEnvironment env = null)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));

            environment = env ?? Environments.Production;
            requester = new Requester(credentials, environment, null, this.apiVersion);

            Account = new AccountResource(requester);
            Balance = new BalanceResource(requester);
            Capability = new CapabilityResource(requester);
            Charges = new ChargeResource(requester);
            Customers = new CustomerResource(requester);
            Disputes = new DisputeResource(requester);
            Events = new EventResource(requester);
            Forex = new ForexResource(requester);
            Links = new LinkResource(requester);
            Occurrences = new OccurrenceResource(requester);
            Sources = new PaymentSourceResource(requester);
            Receipts = new ReceiptResource(requester);
            Recipients = new RecipientResource(requester);
            Refunds = new RefundResource(requester);
            Schedules = new ScheduleResource(requester);
            Tokens = new TokenResource(requester);
            Transactions = new TransactionResource(requester);
            Transfers = new TransferResource(requester);
        }

        public ChargeSpecificResource Charge(string chargeId) => new ChargeSpecificResource(requester, chargeId);
        public CustomerSpecificResource Customer(string customerId) => new CustomerSpecificResource(requester, customerId);
        public RecipientSpecificResource Recipient(string recipientId) => new RecipientSpecificResource(requester, recipientId);
        public ScheduleSpecificResource Schedule(string scheduleId) => new ScheduleSpecificResource(requester, scheduleId);
    }
}