omise-dotnet
============

Omise.Net is a .Net library written in C# provides the wrapper functions for Omise payment API calls.

Requirements
============
The library requires .Net framework 2.0, 3.5, 4.0 or 4.5.

Installation
============
To use the library, simply add a reference to Omise.Net.dll and you are ready to go. The library also available on nuget https://www.nuget.org/packages/Omise.Net/.

Getting started
===============

The core of the library is the Client which contains all services to call the APIs.To initialize the client, you need to have the api secret key.

```c#
  var client = new Omise.Client(YOUR_SECRET_KEY, [YOUR_PUBLIC_KEY]); 
  //public key is optional which is required only if you want to create a token on the server side
```

Creating a token
----------------
**Full Credit Card data should never touch or go through your servers. That means, Do not send the credit card data to Omise from your servers directly.**

The token creation method in the library should only be used either with fake data in test mode (e.g.: quickly creating some fake data, testing our API from a terminal, etc.), or if you do and you are PCI-DSS compliant, sending card data from server requires a valid PCI-DSS certification.
that said, you must achieve, maintain PCI ompliance at all times and do following a Security Best Practices https://www.pcisecuritystandards.org/documents/PCI_DSS_V3.0_Best_Practices_for_Maintaining_PCI_DSS_Compliance.pdf

Creating a token with Omise.js
------------------------------
We recommended you to create a token using [Omise.JS](https://github.com/omise/omise.js) library which runs on browser side. It uses javascript to send the credit card data on client side, send it to Omise, and then you can populate the form with a unique one-time used token which can be used later on.

Simplify the integration with Card.js
-------------------------------------
[Card.js](https://docs.omise.co/card-js/), by using it you can let it builds a credit card payment form window and creates a card token that you can use to create a charge with `omise-dotnet`.


For both methods, the client will directly send the card information to Omise gateway, your servers don't have to deal with card information at all and you don't need to deal with credit card data hassle, it reduces risk.

**Please read https://docs.omise.co/collecting-card-information/ regarding how to collecting card information.**

Creating a charge
-----------------

 ```c#
var chargeInfo = new ChargeCreateInfo ();
chargeInfo.Amount = 10000; //Create a charge with amount 100 THB, here we are passing with the smallest currency unit which is 10000 satangs
chargeInfo.Currency = "THB";
chargeInfo.Description = "Test charge";
chargeInfo.Capture = true; //TRUE means auto capture the charge, FALSE means authorize only. Default is FALSE
chargeInfo.CardId = token; //Token generated with Omise.js or Card.js

var charge = client.ChargeService.CreateCharge(chargeInfo);
 ```

Determine if charge success
---------------------------

In the charge result there is a bool property named 'Captured' which tells us that the money has been charged by the acquirer bank if the value is ```TRUE```, 
otherwise there will be another factors making the charge not being captured. For more information, visit https://docs.omise.co/api/charges/

Creating a customer
-------------------
```c#
var customer = new CustomerInfo();
customer.Email = "test@localhost";
customer.Description = "My test customer";

var customerResult = client.CustomerService.CreateCustomer(customer);
``` 

With the customerResult, you can get access to the customer properties such Id, Email, Description and so on.

Transfer money to bank account
------------------------------
```c#
var result = client.TransferService.CreateTransfer(10000);
//transfer amount is in smallest unit of the currency, for THB the smallest unit is SATANG so here we are transfering 100 THB
```

The transfer will be made to default RECIPIENT which in TEST mode it has been automatically created once you signup to Omise.
However, you have to complete the registration form in order to get LIVE account (with default LIVE recipient) activated. 

Creating a recipient
--------------------
A transfer can also be made to a third-party recipient. The example below demonstrates how to create a recipient.

```c#
var recipientInfo = new RecipientCreateInfo();
recipientInfo.Name = "Test recipient 1";
recipientInfo.Email = "test1@localhost";
recipientInfo.RecipientType = RecipientType.Corporation;
recipientInfo.BankAccount = new BankAccountInfo()
{
Brand = "test",
Number = "1234567890",
Name = "test bank account"
};

var recipient = client.RecipientService.CreateRecipient(recipientInfo);
```

Then to transfer to this recipient

```c#
 var result = client.TransferService.CreateTransfer(10000, recipient.Id);
```

Support banks
-------------

Creating a recipient requires a bank account information. Below are banks that are supported by Omise

|Brand|Full name|
|---|---|
|bbl|Bangkok Bank|
|kbank|Kasikornbank|
|ktb|Krungthai Bank|
|tmb|TMB Bank|
|scb|Siam Commercial Bank|
|citi|Citibank|
|cimb|CIMB Thai Bank|
|uob|United Overseas Bank (Thai)|
|bay|Bank of Ayudhya (Krungsri)|
|tbank|Thanachart Bank|
|ibank|Islamic Bank of Thailand|
|lhb|Land and Houses Bank|


in TEST mode, 'test' brand is also allowed to use.

Full developer api documentation https://docs.omise.co
