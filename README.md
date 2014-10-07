omise-dotnet
============

Omise.Net is a .Net library written in C# provides the wrapper functions for Omise payment API calls.

Requirements
============
The library requires .Net framework 2.0, 3.5, 4.0 or 4.5.

Installation
============
To use the library, simply add a reference to Omise.Net.dll and you are ready to go.

Getting started
===============

The core of the library is the Client which contains all services to call the APIs.To initialize the client, you need to have the api secret key.

```c#
  var client = new Omise.Client(YOUR_API_KEY);
```

Creating a first charge
-----------------------
Creating a charge requires a valid card token, you can create a card token with the card information. If a card token has been used, it cannot be used again.

Creating a token
----------------

```c#
var card = new CardCreateInfo ();
card.Name="TestCard";
card.Number="4242424242424242";
card.ExpirationMonth = 9;
card.ExpirationYear=2017;

var token = new TokenInfo ();
token.Card = card;

var tokenResult = client.TokenService.CreateToken(token);
```

you can then use the tokenResult.Id to create a charge like below

 ```c#
var charge = new ChargeCreateInfo ();
charge.Amount = 1000;
charge.Currency = "THB";
charge.Description = "Test charge";
charge.ReturnUri = "YOUR RETURN URI WHEN CHARGING IS COMPLETED";
charge.Capture = true;
charge.CardId = tokenResult.Id
		
var chargeResult = client.ChargeService.CreateCharge (charge);
 ```

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
