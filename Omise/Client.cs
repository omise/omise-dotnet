using System;
using Omise.Resources;
using Omise.Models;

namespace Omise
{
    public class Client
    {
        readonly Requester requester;

        public readonly AccountResource Account;
        public readonly BalanceResource Balance;
        public readonly ChargeResource Charges;
        public readonly CustomerResource Customers;
        public readonly DisputeResource Disputes;
        public readonly EventResource Events;
        public readonly LinkResource Links;
        public readonly OccurrenceResource Occurrences;
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

        public string APIVersion
        {
            get { return requester.APIVersion; }
            set { requester.APIVersion = value; }
        }

        public Client(string pkey = null, string skey = null)
            : this(new Credentials(pkey, skey))
        {
        }

        public Client(Credentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));
            requester = new Requester(credentials);

            Account = new AccountResource(requester);
            Balance = new BalanceResource(requester);
            Charges = new ChargeResource(requester);
            Customers = new CustomerResource(requester);
            Disputes = new DisputeResource(requester);
            Events = new EventResource(requester);
            Links = new LinkResource(requester);
            Occurrences = new OccurrenceResource(requester);
            Recipients = new RecipientResource(requester);
            Refunds = new RefundResource(requester);
            Schedules = new ScheduleResource(requester);
            Tokens = new TokenResource(requester);
            Transactions = new TransactionResource(requester);
            Transfers = new TransferResource(requester);
        }

        public ChargeSpecificResource Charge(string chargeId) => new ChargeSpecificResource(requester, chargeId);
        public CustomerSpecificResource Customer(string customerId) => new CustomerSpecificResource(requester, customerId);
        public ScheduleSpecificResource Schedule(string scheduleId) => new ScheduleSpecificResource(requester, scheduleId);
    }
}