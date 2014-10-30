using System;

namespace Omise
{
    /// <summary>
    /// A service class defines methods for requesting Balance api
    /// </summary>
    public class BalanceService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.BalanceService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public BalanceService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.BalanceService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        public BalanceService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Gets the Omise balance information.
        /// </summary>
        /// <returns>The balance object.</returns>
        public Balance GetBalance()
        {
            string result = requester.ExecuteRequest("balance", "GET", null);
            return balanceFactory.Create(result);
        }
    }
}

