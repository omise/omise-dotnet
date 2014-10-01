using System;
using System.Collections.Generic;

namespace Omise
{
	public class CustomerService: ServiceBase
	{
		public CustomerService (string apiUrlBase, string apiKey): base(apiUrlBase, apiKey)
		{
		}

		public Customer CreateCustomer (CustomerInfo customer)
		{
			if (!customer.Valid)
				throw new InvalidCardException (getObjectErrors(customer)); 
			string result = requester.ExecuteRequest ("/customers", "POST", customer.ToRequestParams ());
			return customerFactory.Create (result);
		}

		public Customer GetCustomer(string customerId){
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required."); 
			string result = requester.ExecuteRequest ("/customers/" + customerId, "GET", null);
			return customerFactory.Create (result);
		}

		public Customer UpdateCustomer(string customerId, CustomerInfo customer){
			if (string.IsNullOrEmpty (customerId))
				throw new ArgumentException ("customerId is required."); 
			if (!customer.Valid)
				throw new InvalidCustomerException ("Customer is invalid.");
			var result = requester.ExecuteRequest ("/customers/" + customerId, "PATCH", customer.ToRequestParams());
			return customerFactory.Create (result);
		}

		public void DeleteCustomer(string customerId){
			if (string.IsNullOrEmpty(customerId))
				throw new ArgumentException ("customerId is required."); 
			requester.ExecuteRequest ("/customers/" + customerId, "DELETE", null);
		}
	}
}

