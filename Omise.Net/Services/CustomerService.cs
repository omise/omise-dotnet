using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Defines methods for requesting Customer api
    /// </summary>
    public class CustomerService : ServiceBase
    {
        private TokenService tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with Api key and TokenService object. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        public CustomerService(string apiKey, TokenService tokenService)
            : base(apiKey)
        {
            if (tokenService == null)
                throw new ArgumentNullException("tokenService");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with IRequestManager object, Api key and TokenService object.
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        public CustomerService(IRequestManager requestManager, string apiKey, TokenService tokenService)
            : base(requestManager, apiKey)
        {
            if (tokenService == null)
                throw new ArgumentNullException("tokenService");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <returns>Customer object</returns>
        /// <param name="customer">Customer information</param>
        public Customer CreateCustomer(CustomerInfo customerCreateInfo)
        {
            if (customerCreateInfo == null)
                throw new ArgumentNullException("customerCreateInfo");
            if (!customerCreateInfo.Valid)
                throw new InvalidCustomerException(getObjectErrors(customerCreateInfo));
            
            if (customerCreateInfo.CardCreateInfo != null)
            {
                var tokenResult = this.tokenService.CreateToken(new TokenInfo()
                    {
                        Card = customerCreateInfo.CardCreateInfo
                    });

                customerCreateInfo.CardToken = tokenResult.Id;
            }

            string result = requester.ExecuteRequest("/customers", "POST", customerCreateInfo.ToRequestParams());
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <returns>Customer object</returns>
        /// <param name="customerId">Customer Id</param>
        public Customer GetCustomer(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId");
            string result = requester.ExecuteRequest("/customers/" + customerId, "GET", null);
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <returns>Customer object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="customer">Customer Information</param>
        public Customer UpdateCustomer(string customerId, CustomerInfo customerInfo)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId");
            if (customerInfo == null)
                throw new ArgumentNullException("customerUpdateInfo");
            if (!customerInfo.Valid)
                throw new InvalidCustomerException(getObjectErrors(customerInfo));

            if (customerInfo.CardCreateInfo != null)
            {
                var tokenResult = this.tokenService.CreateToken(new TokenInfo()
                    {
                        Card = customerInfo.CardCreateInfo
                    });

                customerInfo.CardToken = tokenResult.Id;
            }
            string result = requester.ExecuteRequest("/customers/" + customerId, "PATCH", customerInfo.ToRequestParams());
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <returns>The result of deleting the object</returns>
        /// <param name="customerId">Customer Id</param>
        public DeleteResponseObject DeleteCustomer(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId");
            string result = requester.ExecuteRequest("/customers/" + customerId, "DELETE", null);
            return JsonConvert.DeserializeObject<DeleteResponseObject>(result);
        }
    }
}

