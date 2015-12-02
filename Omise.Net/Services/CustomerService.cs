using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Omise.Net;

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
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with Api key and TokenService object. The service uses default IRequestManager object.
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="tokenService">TokenService object</param>
        /// <param name="apiVersion">Api version</param>
        public CustomerService(string apiKey, TokenService tokenService, string apiVersion)
            : base(apiKey, apiVersion)
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
        /// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with IRequestManager object, Api key and TokenService object.
        /// </summary>
        /// <param name="requestManager">IRequestManager object.</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="tokenService">TokenService object</param>
        /// <param name="apiVersion">Api version</param>
        public CustomerService(IRequestManager requestManager, string apiKey, TokenService tokenService, string apiVersion)
            : base(requestManager, apiKey, apiVersion)
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

        internal CustomerService(IRequestManager requestManager, Credentials credentials, TokenService tokenService, string apiVersion)
            : base(requestManager, credentials, apiVersion)
        {
            if (tokenService == null)
                throw new ArgumentNullException("tokenService");

            this.tokenService = tokenService;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>CollectionResponseObject of customers.</returns>
        public CollectionResponseObject<Customer> GetAllCustomers()
        {
            return GetAllCustomers(null, null, null, null);
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>CollectionResponseObject of customers.</returns>
        /// <param name="from">Start date of customer creation to scope the result</param>
        /// <param name="to">End date of customer creation to scope the result</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit the numbers of return records</param>
        public CollectionResponseObject<Customer> GetAllCustomers(DateTime? from, DateTime? to, int? offset, int? limit)
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

            string url = "/customers" + (parameters.Count > 0 ? "?" + string.Join("&", parameters.ToArray()) : "");
            string result = requester.ExecuteRequest(url, "GET", null);
            return customerFactory.CreateCollection(result);
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
        public Customer UpdateCustomer(CustomerInfo customerInfo)
        {
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
            string result = requester.ExecuteRequest("/customers/" + customerInfo.Id, "PATCH", customerInfo.ToRequestParams());
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <returns>The result of deleting the object</returns>
        /// <param name="customerId">Customer Id</param>
        public Customer DeleteCustomer(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId");
            string result = requester.ExecuteRequest("/customers/" + customerId, "DELETE", null);
            return customerFactory.Create(result);
        }

        /// <summary>
        /// Update the customer's default card. Set the customer's default card to specified card id
        /// </summary>
        /// <returns>Customer object</returns>
        /// <param name="customerId">Customer Id</param>
        /// <param name="cardId">Card Id</param>
        public Customer UpdateDefaultCard(string customerId, string cardId)
        {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException("customerId");
            if (string.IsNullOrEmpty(cardId))
                throw new ArgumentNullException("cardId");

            string result = requester.ExecuteRequest("/customers/" + customerId, "PATCH", string.Format("default_card={0}", cardId));
            return customerFactory.Create(result);
        }
    }
}

