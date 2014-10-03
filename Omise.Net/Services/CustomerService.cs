using System;
using System.Collections.Generic;

namespace Omise
{
	public class CustomerService: ServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with api url and api key. The service uses default IRequestManager object.
		/// </summary>
		/// <param name="apiUrlBase">API base URL.</param>
		/// <param name="apiKey">API key.</param>
		public CustomerService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.CustomerService"/> class with IRequestManager object, api url and api key.
		/// </summary>
		/// <param name="requestManager">IRequestManager object.</param>
		/// <param name="apiUrlBase">API base URL.</param>
		/// <param name="apiKey">API key.</param>
		public CustomerService (IRequestManager requestManager, string apiUrlBase, string apiKey): base(requestManager, apiUrlBase, apiKey)
		{
		}

		/// <summary>
		/// Creates the customer.
		/// </summary>
		/// <returns>Omise customer object</returns>
		/// <param name="customer">CustomerInfo object.</param>
		public Customer CreateCustomer (CustomerInfo customer)
		{
			if (customer == null)
				throw new ArgumentNullException ("Customer info is required.");
			if (!customer.Valid)
				throw new InvalidCardException (getObjectErrors(customer)); 
			string result = requester.ExecuteRequest ("/customers", "POST", customer.ToRequestParams ());
			return customerFactory.Create (result);
		}

		/// <summary>
		/// Gets the customer.
		/// </summary>
		/// <returns>Omise Customer object.</returns>
		/// <param name="customerId">Customer Id.</param>
		public Customer GetCustomer(string customerId){
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentNullException ("customerId is required."); 
			string result = requester.ExecuteRequest ("/customers/" + customerId, "GET", null);
			return customerFactory.Create (result);
		}

		/// <summary>
		/// Updates the customer.
		/// </summary>
		/// <returns>Omise Customer object.</returns>
		/// <param name="customerId">Customer Id.</param>
		/// <param name="customer">CustomerInfo object.</param>
		public Customer UpdateCustomer(string customerId, CustomerInfo customer){
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentNullException ("customerId is required."); 
			if (customer == null)
				throw new ArgumentNullException ("Customer info is required.");
			if (!customer.Valid)
				throw new InvalidCustomerException ("Customer is invalid.");
			var result = requester.ExecuteRequest ("/customers/" + customerId, "PATCH", customer.ToRequestParams());
			return customerFactory.Create (result);
		}

		/// <summary>
		/// Deletes the customer.
		/// </summary>
		/// <param name="customerId">Customer Id.</param>
		public void DeleteCustomer(string customerId){
			if (string.IsNullOrEmpty(customerId))
				throw new ArgumentNullException ("customerId is required."); 
			requester.ExecuteRequest ("/customers/" + customerId, "DELETE", null);
		}
	}
}

