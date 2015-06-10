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

**Please read https://docs.omise.co/collecting-card-information/ for full developer api documentation.**