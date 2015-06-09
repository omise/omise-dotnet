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

Creating a first charge
-----------------------
Creating a charge requires a valid card token, you can create a card token with the card information.
We recommended you to create a token using Omise.JS library which runs on browser side, the client will directly send the card information to Omise gateway so that your server doesn't have to deal with card information at all. However, the library also provides way to create a card token as below example (create a card token on server side requires PCI compliance on your system)

Creating a token
----------------

```c#
var card = new CardCreateInfo ();
card.Name="TestCard";
card.Number="4242424242424242";
card.ExpirationMonth = 9;
card.ExpirationYear=2017;
card.SecurityCode = "123";

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
charge.Capture = true; //TRUE means auto capture the charge, FALSE means authorize only. Default is FALSE
charge.CardId = tokenResult.Id;
		
var chargeResult = client.ChargeService.CreateCharge (charge);
 ```

Determine if charge success
---------------------------

In the charge result there is a bool property named 'Captured' which tells us that the money has been charged by the acquirer bank if the value is ```TRUE```, 
otherwise there will be another factors making the charge not being captured. For more information, visit https://docs.omise.co/api/charges/
 
Getting a token
---------------

```c#
var tokenResult = client.TokenService.GetToken("tkn_xxxxxxxxxxxx");
```

Getting a charge
----------------

```c#
var chargeResult = client.ChargeService.GetCharge("12345");
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
