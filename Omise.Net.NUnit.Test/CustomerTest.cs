using System;
using NUnit.Framework;

namespace Omise.Net.NUnit.Test
{
	[TestFixture]
	public class CustomerTest:TestBase
	{
		private Customer customer;

		[SetUp]
		public override void Setup(){
			base.Setup ();
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test1@localhost";
			customerInfo.Description = "Test customer 1";
			customer = client.CustomerService.CreateCustomer (customerInfo);
		}

		[Test]
		public void TestCreateCustomer(){
			var customerInfo = new CustomerInfo ();
			customerInfo.Email = "test2@localhost";
			customerInfo.Description = "Test customer 2";

			var customerResult = client.CustomerService.CreateCustomer (customerInfo);
			Assert.IsNotNull (customerResult);
			Assert.AreEqual ("test2@localhost", customerResult.Email);
			Assert.IsNotNull (customerResult.Id);
		}

		[Test]
		public void TestUpdateCustomer(){
			var customerUpdateInfo = new CustomerInfo ();
			customerUpdateInfo.Email = "test11@localhost";
			customerUpdateInfo.Description = "Test Customer 11 change email";
			var customerUpdateResult = client.CustomerService.UpdateCustomer (customer.Id, customerUpdateInfo);
			Assert.AreEqual ("test11@localhost", customerUpdateResult.Email);
			Assert.AreEqual ("Test Customer 11 change email", customerUpdateResult.Description);
		}

		[Test]
		public void TestDeleteCustomer(){
			client.CustomerService.DeleteCustomer (customer.Id);
			Assert.Throws<ApiException>(delegate { client.CustomerService.GetCustomer (customer.Id); } );
		}

		[Test]
		public void TestGetCustomerInfo(){
			var customerShowResult = client.CustomerService.GetCustomer (customer.Id);
			Assert.IsNotNull (customerShowResult);
			Assert.AreEqual ("test1@localhost", customerShowResult.Email);
			Assert.AreEqual ("Test customer 1", customerShowResult.Description);
		}
	}
}

