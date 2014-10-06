omise-dotnet
============

Omise.Net is a .Net library written in C# which provides the wrapper functions for Omise payment API calls.

Requirements
============
The library requires .Net framework 2.0, 3.5, 4.0 and 4.5.

Installation
============
To use the library, simply add a reference to Omise.Net.dll and you are ready to go.

Getting started
===============

The core of the library is the Client which contains all services to call the APIs.To initialize the client, you need to have the api url and api secret key.

```c#
  var client = new Omise.Client(YOUR_API_KEY, API_URL);
```

Creating a first charge
-----------------------
Omise Payment API provides convenient ways to create a charge. Note that the result of creating a charge is a Charge object.

Creating a charge with card informations. This way you can make a charge to any card even if the card's holder is not your customer.

 ```c#
var charge = new ChargeCreateInfo ();
charge.Amount = 1000;
charge.Currency = "THB";
charge.Description = "Test charge";
charge.ReturnUri = "YOUR RETURN URI WHEN CHARGING IS COMPLETED";
charge.Capture = true;

var card = new CardCreateInfo ();
card.ExpirationMonth = 9;
card.ExpirationYear = 2017;
card.Number = "4242424242424242";
card.Name = "Test card";
charge.Card = card;
		
var chargeResult = client.ChargeService.CreateCharge (charge);
 ```

Omise API also provides the following options for creating a charge 
1. with a specific card id
2. with a customer default card
3. with a card token

Creating a customer
-------------------
```c#
var customer = new CustomerInfo();
customer.Email = "test@localhost";
customer.Description = "My test customer";

var customerResult = client.CustomerService.CreateCustomer(customer);
``` 

With the customerResult, you can get access to the customer properties such Id, Email, Description and so on.

Creating a card
---------------
Creating a card requires an existing customer. Below is the sample code

```c#
var card = new CardCreateInfo ();
card.Name="Test Card";
card.Number = "4242424242424242";
card.ExpirationMonth=9;
card.ExpirationYear=2017;

var createCardResult = client.CardService.CreateCard(YOUR_CUSTOMER_ID, card);
```

the result of creating a card is a Card object.
