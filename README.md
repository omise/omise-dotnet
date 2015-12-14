# OMISE-DOTNET

[![Join the chat at https://gitter.im/omise/omise-dotnet](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/omise/omise-dotnet?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![Build Status](https://travis-ci.org/omise/omise-dotnet.svg)](https://travis-ci.org/omise/omise-dotnet)

**This library has been updated to v2.0, check the v1 branch for the previous version.**

Omise.Net is a NuGet package for CLR platforms (.NET/Mono) written in C#. This package
provides a set of bindings to the [Omise REST API](https://www.omise.co/docs).

Please contact [chakrit@omise.co](mailto:chakrit@omise.co) or
[support@omise.co](mailto:support@omise.co) if you have any question regarding this
library and the functionality it provides.

# REQUIREMENTS

You will need to obtain the Omise public and secret API keys in order to use this package.
You can obtain them by [registering on our website](https://dashboard.omise.co/signup).

The library targets the Portable Class Library (PCL) 4.0 (Profile147) and should works on
the following list of platforms:

* .NET Framework 4.0.3 or later
* Windows Phone 8 or later
* Silverlight 5
* Windows 8
* Windows Phone Silverlight 8
* Windows Store apps (Windows 8)
* Xamarin.Android
* Xamarin.iOS Classic
* Xamarin.iOS Unified
* Xamarin.Mac Unified

# INSTALLATION

### NuGet

The easiest way to get going with this library is via NuGet packages:

```
> Install-Package omise
```

### Manually

Or you can compile this library manually and add reference to Omise.Net.dll. The library
also depends on the following packages/assemblies:

* Microsoft.Threading.Tasks (via Microsoft.Async package)
* System.Net.Http (via Microsoft.Net.Http package)

# GETTING STARTED

The core of the library is the Client which contains services to call the APIs.To
initialize the client, you need to have the API keys. Visit the [Omise
Dashboard](https://dashboard.omise.co/test/api-keys) to obtain your API keys.

```c#
using Omise;

var client = new Client([YOUR_PUBLIC_KEY], [YOUR_SECRET_KEY]);
```

You must specify at least one key. Usually you will only need the secret key so a shorter
form may be more preferrable:

```c#
var client = new Client(skey: "YOUR_SECRET_KEY");
```

You may also specify specific API version to use:

```c#
var client = new Omise.Client([YOUR_PUBLIC_KEY], [YOUR_SECRET_KEY]);
client.APIVersion = "2014-07-27";
```

# DEVELOPMENT / TESTING

All tests in this library are against fixture files. There is no network test implemented.
Since we target the PCL even for the test code, the fixture data files are imported as
C# byte slices via a T4 template.

# TASKS

Following is a list of example code for common tasks you can perform with this package.
Note that, despite this library allowing you to do so, you should never need to transmit
credit card data through your server directly. **Please read our [Security Best
Practices](https://www.omise.co/security-best-practices) guideline before deploying
production code using this package.**

### Creating a Charge with a Token

```c#
var token = GetToken();
var charge = Client.Charges.Create(new CreateChargeRequest
    {
        Amount = 200000 // 2,000.00 THB
        Currency = "thb",
        Card = token.Id
    })
    .Result;

Print("created charge: " + charge.Id);
```

The API calls returns `Task<TResult>` so if your development platforms support C#'s
`async` and `await`, you can also use it with this package:

```c#
var charge = await client.Charges.Create(new CreateChargeRequest { })
```

### Creating a Customer, then a Charge

```c#
var token = GetToken();
var customer = await Client.Customers.Create(new CreateCustomerRequest
    {
        Email = "customers_email@example.com",
        Description = "customer#1234",
        Card = token.Id
    });

Print("created customer: {0}", customer.Id);

var charge = await Client.Charges.Create(new CreateChargeRequest
    {
        Customer = customer.Id,
        Amount = 200000, // 2,000.00 THB
        Currency = "thb"
    });

Print("created charge: {0}", charge.Id);
```

### Transferring money to the default Recipient.

```c#
var transfer = await Client.Transfers.Create(new CreateTransferRequest
    {
        Amount = 1000000 // 10,000.00 THB
    });

Print("created transfer: {0}", transfer.Id);
```

### Transferring money to a new Recipient.

```c#
var recipient = await Client.Recipients.Create(new CreateRecipientRequest
    {
        Name = "Merchant X Smith",
        Email = "john.doe@example.com",
        Description = "merchant#456",
        Type = RecipientType.Individual,
        BankAccount = new BankAccountRequest
        {
            Brand = "bank",
            Number = "7777-777-777",
            Name = "Smith X.",
        }
    });

Print("created recipient: {0}", recipient.Id);

var transfer = await Client.Transfers.Create(new CreateTransferRequest
    {
        Amount = 99900, // 999.00 THB
        Recipient = recipient.Id
    });

Print("created transfer: {0}", transfer.Id);
```

# IMPORTANT NOTE ABOUT MERCHANT COMPLIANCE

Card data should never transit through your server. This library provides means to create
card tokens server-side but should only be used for testing or if you currently have valid
PCI-DSS Attestation of Compliance (AoC) delivered by a certified QSA Auditor

Instead we recommend that you follow our guide on how to safely [collect credit card
information](https://www.omise.co/collecting-card-information)

# LICENSE

MIT, See [LICENSE](https://github.com/omise/omise-dotnet/blob/master/LICENSE)
file for the full text.
