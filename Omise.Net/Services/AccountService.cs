using System;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting Account api
    /// </summary>
    public class AccountService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.AccountService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public AccountService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.AccountService"/> class with Api key. The service uses default request manager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public AccountService(string apiKey, string apiVersion)
            : base(apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.AccountService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        public AccountService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.AccountService"/> class with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public AccountService(IRequestManager requestManager, string apiKey, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
        {
        }

        /// <summary>
        /// Gets the Omise account information.
        /// </summary>
        /// <returns>The Omise account object.</returns>
        public Account GetAccount()
        {
            string result = requester.ExecuteRequest("/account", "GET", null);
            return accountFactory.Create(result);
        }
    }
}

