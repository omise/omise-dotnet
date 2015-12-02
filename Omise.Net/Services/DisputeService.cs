using System;
using System.Collections.Generic;
using System.Text;
using Omise.Net;

namespace Omise
{
    public class DisputeService : ServiceBase
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="Omise.DisputeService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey"></param>
        public DisputeService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Omise.DisputeService"/> class with Api key and Api version. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiVersion"></param>
        public DisputeService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.DisputeService"/> class with IRequestManager object and Api key.
        /// </summary>
        /// <param name="requestManager"></param>
        /// <param name="apiKey"></param>
        public DisputeService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {

        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Omise.DisputeService"/> class with IRequestManager object, Api key and Api version.
        /// </summary>
        /// <param name="requestManager"></param>
        /// <param name="apiKey"></param>
        /// <param name="apiVersion"></param>
        public DisputeService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {

        }

        internal DisputeService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }

        public Dispute GetDispute(string disputeId){
            if (string.IsNullOrEmpty(disputeId))
                throw new ArgumentNullException("disputeId");

            string url = string.Format("/disputes/{0}", disputeId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return disputeFactory.Create(result);
        }

        public Dispute UpdateDispute(string disputeId, string message)
        {
            if (string.IsNullOrEmpty(disputeId))
                throw new ArgumentNullException("disputeId");

            string result = requester.ExecuteRequest("/disputes/" + disputeId, "PATCH", "message=" + message);
            return disputeFactory.Create(result);
        }

        public CollectionResponseObject<Dispute> GetAllDisputes() {
            return QueryDisputes(null, null, null, null);
        }

        public CollectionResponseObject<Dispute> GetAllDisputes(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            return QueryDisputes(from, to, offset, limit);
        }

        public CollectionResponseObject<Dispute> GetAllOpenDisputes() {
            return QueryDisputes(null, null, null, null, "open");
        }

        public CollectionResponseObject<Dispute> GetAllPendingDisputes() {
            return QueryDisputes(null, null, null, null, "pending");
        }

        public CollectionResponseObject<Dispute> GetAllClosedDisputes(){
            return QueryDisputes(null, null, null, null, "closed");
        }

        public CollectionResponseObject<Dispute> GetAllOpenDisputes(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            return QueryDisputes(from, to, offset, limit, "open");
        }

        public CollectionResponseObject<Dispute> GetAllPendingDisputes(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            return QueryDisputes(from, to, offset, limit, "pending");
        }

        public CollectionResponseObject<Dispute> GetAllClosedDisputes(DateTime? from, DateTime? to, int? offset, int? limit)
        {
            return QueryDisputes(from, to, offset, limit, "closed");
        }

        private CollectionResponseObject<Dispute> QueryDisputes(DateTime? from, DateTime? to, int? offset, int? limit, string subEndpoint = "")
        {
            var parameters = BuildPaginationParams(from, to, offset, limit);
            var endpoint = "/disputes/" + subEndpoint;
            string url = endpoint + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return disputeFactory.CreateCollection(result);
        }
    }
}
