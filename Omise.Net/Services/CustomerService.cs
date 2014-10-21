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
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with api key and TokenService object. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        public CustomerService(string apiKey, TokenService tokenService)
            : base(apiKey)
        {
            if (tokenService == null)
                throw new ArgumentNullException("TokenService is required");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with IRequestManager object, api key and TokenService object.
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">API key.</param>
        public CustomerService(IRequestManager requestManager, string apiKey, TokenService tokenService)
            : base(requestManager, apiKey)
        {
            if (tokenService == null)
                throw new ArgumentNullException("TokenService is required");
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <returns>Omise customer object</returns>
        /// <param name="customer">CustomerInfo object.</param>
        public Customer CreateCustomer(CustomerCreateInfo customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer info is required.");
            if (!customer.Valid)
                throw new InvalidCustomerException(getObjectErrors(customer));
            
            if (customer.CardCreateInfo != null) {
                var tokenResult = this.tokenService.CreateToken(new TokenInfo()
                {
                    Card = customer.CardCreateInfo
                });

                customer.CardToken = tokenResult.Id;
            }

            string result = requester.ExecuteRequest("/customers", "POST", customer.ToRequestParams());
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <returns>Omise Customer object.</returns>
        /// <param name="customerId">Customer Id.</param>
        public Customer GetCustomer(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId is required.");
            string result = requester.ExecuteRequest("/customers/" + customerId, "GET", null);
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <returns>Omise Customer object.</returns>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="customer">CustomerInfo object.</param>
        public Customer UpdateCustomer(string customerId, CustomerUpdateInfo customer)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId is required.");
            if (customer == null)
                throw new ArgumentNullException("Customer info is required.");
            if (!customer.Valid)
                throw new InvalidCustomerException("Customer is invalid.");

            if (customer.CardCreateInfo != null)
            {
                var tokenResult = this.tokenService.CreateToken(new TokenInfo()
                {
                    Card = customer.CardCreateInfo
                });

                customer.CardToken = tokenResult.Id;
            }
            string result = requester.ExecuteRequest("/customers/" + customerId, "PATCH", customer.ToRequestParams());
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
                throw new ArgumentNullException("customerId is required.");
            string result = requester.ExecuteRequest("/customers/" + customerId, "DELETE", null);
            return JsonConvert.DeserializeObject<DeleteResponseObject>(result);
        }
    }
}

