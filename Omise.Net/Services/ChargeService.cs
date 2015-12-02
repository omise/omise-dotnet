using System;
using System.Collections.Generic;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting Charge api
    /// </summary>
    public class ChargeService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public ChargeService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public ChargeService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public ChargeService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public ChargeService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {
        }

        internal ChargeService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }

        /// <summary>
        /// Creates a charge.
        /// </summary>
        /// <returns>Charge object</returns>
        /// <param name="chargeInfo">Charge information</param>
        public Charge CreateCharge(ChargeCreateInfo chargeCreateInfo)
        {
            if (chargeCreateInfo == null)
                throw new ArgumentNullException("chargeCreateInfo");
            if (!chargeCreateInfo.Valid)
                throw new InvalidChargeException(getObjectErrors(chargeCreateInfo));
            string result = requester.ExecuteRequest("/charges", "POST", chargeCreateInfo.ToRequestParams());
            return chargeFactory.Create(result);
        }

        /// <summary>
        /// Updates a charge.
        /// </summary>
        /// <returns>Charge object</returns>
        /// <param name="chargeUpdateInfo">Charge information</param>
        public Charge UpdateCharge(ChargeUpdateInfo chargeUpdateInfo)
        {
            if (chargeUpdateInfo == null)
                throw new ArgumentNullException("chargeUpdateInfo");
            if (!chargeUpdateInfo.Valid)
                throw new InvalidChargeException(getObjectErrors(chargeUpdateInfo));
            string result = requester.ExecuteRequest("/charges/" + chargeUpdateInfo.Id, "PATCH", chargeUpdateInfo.ToRequestParams());
            return chargeFactory.Create(result);
        }

        /// <summary>
        /// Gets all charges.
        /// </summary>
        /// <returns>CollectionResponseObject of charges.</returns>
        public CollectionResponseObject<Charge> GetAllCharges() {
            return GetAllCharges(null, null, null, null);
        }

        /// <summary>
        /// Gets all charges.
        /// </summary>
        /// <returns>CollectionResponseObject of charges.</returns>
        /// <param name="from">Start date of charge creation to scope the result</param>
        /// <param name="to">End date of charge creation to scope the result</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit the numbers of return records</param>
        public CollectionResponseObject<Charge> GetAllCharges(DateTime? from, DateTime? to, int? offset, int? limit)
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

            string url = "/charges" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return chargeFactory.CreateCollection(result);
        }

        /// <summary>
        /// Gets a charge.
        /// </summary>
        /// <returns>Charge object</returns>
        /// <param name="chargeId">Charge Id</param>
        public Charge GetCharge(string chargeId)
        {
            if (string.IsNullOrEmpty(chargeId))
                throw new ArgumentNullException("chargeId");

            string url = string.Format("/charges/{0}", chargeId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return chargeFactory.Create(result);
        }

        /// <summary>
        /// Creates a refund.
        /// </summary>
        /// <returns>The refund.</returns>
        /// <param name="chargeId">Charge id</param>
        /// <param name="amount">Amount</param>
        public Refund CreateRefund(string chargeId, int amount)
        {
            if (string.IsNullOrEmpty(chargeId))
                throw new ArgumentNullException("chargeId");

            if (amount <= 0)
                throw new ArgumentException("amount must be greater than 0");

            string url = string.Format("/charges/{0}/refunds", chargeId);
            string result = requester.ExecuteRequest(url, "POST", "amount=" + amount);
            return refundFactory.Create(result);
        }

        /// <summary>
        /// Gets the refund detail
        /// </summary>
        /// <returns>The refund.</returns>
        /// <param name="chargeId">Charge id</param>
        /// <param name="refundId">Refund id</param>
        public Refund GetRefund(string chargeId, string refundId)
        {
            if (string.IsNullOrEmpty(chargeId))
                throw new ArgumentNullException("chargeId");

            if (string.IsNullOrEmpty(refundId))
                throw new ArgumentNullException("refundId");

            string url = string.Format("/charges/{0}/refunds/{1}", chargeId, refundId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return refundFactory.Create(result);
        }

        /// <summary>
        /// Gets the refunds of the charge
        /// </summary>
        /// <returns>CollectionResponseObject of refund</returns>
        /// <param name="chargeId">Charge id</param>
        public CollectionResponseObject<Refund> GetRefunds(string chargeId)
        {
            if (string.IsNullOrEmpty(chargeId))
                throw new ArgumentNullException("chargeId");

            string url = string.Format("/charges/{0}/refunds", chargeId);
            string result = requester.ExecuteRequest(url, "GET", null);
            return refundFactory.CreateCollection(result);
        }

        /// <summary>
        /// Captures an authorized-only charge. The authorized-only charge is a charge that created with Capture = false.
        /// </summary>
        /// <param name="chargeId">Charge id</param>
        /// <returns>Charge object</returns>
        public Charge Capture(string chargeId)
        {
            if (string.IsNullOrEmpty(chargeId))
                throw new ArgumentNullException("chargeId");

            string url = string.Format("/charges/{0}/capture", chargeId);
            string result = requester.ExecuteRequest(url, "POST", null);
            return chargeFactory.Create(result);
        }
    }
}

