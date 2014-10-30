using System;

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
        /// Initializes a new instance of the <see cref="Omise.ChargeService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public ChargeService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
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
        /// Gets the charge.
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
    }
}

