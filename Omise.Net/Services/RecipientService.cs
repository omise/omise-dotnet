using System;
using Newtonsoft.Json;

namespace Omise
{
    public class RecipientService: ServiceBase
    {
        public RecipientService(string apiKey)
            : base(apiKey)
        {
        }

        public RecipientService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {

        }

        public Recipient GetRecipient(string recipientId)
        {
            if (string.IsNullOrEmpty(recipientId))
            {
                throw new ArgumentNullException("recipientId");
            }

            string result = requester.ExecuteRequest("recipients/" + recipientId, "GET", null);
            return recipientFactory.Create(result);
        }

        public Recipient CreateRecipient(RecipientInfo recipientInfo)
        {
            if (recipientInfo == null)
            {
                throw new ArgumentNullException("recipientInfo");
            }

            if (!recipientInfo.Valid)
            {
                throw new InvalidRecipientException(getObjectErrors(recipientInfo));
            }

            string result = requester.ExecuteRequest("recipients/", "POST", recipientInfo.ToRequestParams());
            return recipientFactory.Create(result);
        }

        public Recipient UpdateRecipient(RecipientInfo recipientInfo)
        {
            if (recipientInfo == null)
            {
                throw new ArgumentNullException("recipientInfo");
            }

            if (!recipientInfo.Valid)
            {
                throw new InvalidRecipientException(getObjectErrors(recipientInfo));
            }

            string result = requester.ExecuteRequest("recipients/" + recipientInfo.Id, "PATCH", recipientInfo.ToRequestParams());
            return recipientFactory.Create(result);
        }

        public Recipient DeleteRecipient(string recipientId)
        {
            if (string.IsNullOrEmpty(recipientId))
                throw new ArgumentNullException("recipientId");
            string result = requester.ExecuteRequest("/recipients/" + recipientId, "DELETE", null);
            return recipientFactory.Create(result);
        }

        public BankAccount GetBankAccount(string recipientId, string bankAccountId)
        {
            var result = requester.ExecuteRequest(string.Format("recipients/{0}/bank_accounts/{1}", recipientId, bankAccountId), "GET", null);
            return bankAccountFactory.Create(result);
        }

        public CollectionResponseObject<BankAccount> GetBankAccounts(string recipientId)
        {
            var result = requester.ExecuteRequest(string.Format("recipients/{0}/bank_accounts", recipientId), "GET", null);
            return bankAccountFactory.CreateCollection(result);
        }

        public BankAccount UpdateBankAccount(string recipientId, BankAccountInfo bankAccountInfo)
        {
            var result = requester.ExecuteRequest(string.Format("recipients/{0}/bank_accounts/{1}", recipientId, bankAccountInfo.Id), "PATCH", bankAccountInfo.ToRequestParams());
            return bankAccountFactory.Create(result);
        }

        public BankAccount DeleteBankAccount(string recipientId, string bankAccountId)
        {
            var result = requester.ExecuteRequest(string.Format("recipients/{0}/bank_accounts/{1}", recipientId, bankAccountId), "DELETE", null);
            return bankAccountFactory.Create(result);
        }
    }
}

