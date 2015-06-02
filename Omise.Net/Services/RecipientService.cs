using System;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public CollectionResponseObject<Recipient> GetAllRecipients() {
            return GetAllRecipients(null, null, null, null);
        }

        public CollectionResponseObject<Recipient> GetAllRecipients(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            var parameters = new List<string>();
            if (from.HasValue)
            {
                parameters.Add("from=" + DateTimeHelper.ToApiDateString(from.Value));
            }
            if (to.HasValue)
            {
                parameters.Add("to=" + DateTimeHelper.ToApiDateString(to.Value));
            }
            if (offset.HasValue)
            {
                parameters.Add("offset=" + offset.Value);
            }
            if (limit.HasValue)
            {
                parameters.Add("limit=" + limit.Value);
            }

            string url = "/recipients" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return recipientFactory.CreateCollection(result);
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

        public Recipient CreateRecipient(RecipientCreateInfo recipientCreateInfo)
        {
            if (recipientCreateInfo == null)
            {
                throw new ArgumentNullException("recipientCreateInfo");
            }

            if (!recipientCreateInfo.Valid)
            {
                throw new InvalidRecipientException(getObjectErrors(recipientCreateInfo));
            }

            string result = requester.ExecuteRequest("recipients/", "POST", recipientCreateInfo.ToRequestParams());
            return recipientFactory.Create(result);
        }

        public Recipient UpdateRecipient(RecipientUpdateInfo recipientUpdateInfo)
        {
            if (recipientUpdateInfo == null)
            {
                throw new ArgumentNullException("recipientUpdateInfo");
            }

            if (!recipientUpdateInfo.Valid)
            {
                throw new InvalidRecipientException(getObjectErrors(recipientUpdateInfo));
            }

            string result = requester.ExecuteRequest("recipients/" + recipientUpdateInfo.Id, "PATCH", recipientUpdateInfo.ToRequestParams());
            return recipientFactory.Create(result);
        }

        public Recipient DeleteRecipient(string recipientId)
        {
            if (string.IsNullOrEmpty(recipientId))
                throw new ArgumentNullException("recipientId");
            string result = requester.ExecuteRequest("/recipients/" + recipientId, "DELETE", null);
            return recipientFactory.Create(result);
        }
    }
}

