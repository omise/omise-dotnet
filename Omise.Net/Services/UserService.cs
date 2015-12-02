using System;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting User api
    /// </summary>
    public class UserService : ServiceBase
    {
        /// <summary>
        /// Initialize the UserService instance with Api key
        /// </summary>
        /// <param name="apiKey"></param>
        public UserService(string apiKey)
            : base(apiKey)
        {
        }

        /// <summary>
        /// Initialize the UserService instance with IRequestManager object and Api key
        /// </summary>
        /// <param name="requestManager">IRequestManager object</param>
        /// <param name="apiKey">Api key</param>
        public UserService(IRequestManager requestManager, string apiKey)
            : base(requestManager, apiKey)
        {
        }

        internal UserService(IRequestManager requestManager, Credentials credentials, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
        }
    }
}

