# Omise-Dotnet

[![NuGet](https://img.shields.io/nuget/v/Omise.svg?style=flat-square)](https://www.nuget.org/packages/Omise/)
[![.NET](https://github.com/omise/omise-dotnet/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/omise/omise-dotnet/actions/workflows/dotnet-core.yml)

**This library has been updated to v2.0, check the v1 branch for the previous version.**

Omise.Net is a NuGet package for CLR platforms (.NET Standard) written in C#.  This
library is developed on OS X using Visual Studio for Mac.  This package provides a set of
bindings to the [Opn Payments REST API](https://docs.opn.ooo/).

Please contact
[support@opn.ooo](mailto:support@opn.ooo) if you have any question regarding this
library and the functionality it provides.

# Requirements

You will need to obtain the Opn Payments public and secret API keys in order to use this package.
You can obtain them by [registering on our website](https://dashboard.omise.co/signup).

**PCL support is removed since v2.5, the library now targets .NET Standard instead.**

This library targets the .NET Standard version 2.0. For an updated list of supported
platforms and compatibility with projects that target the PCL, please consult
[Official Microsoft's Documentation on .NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard).

# Installation

### NuGet

The easiest way to get going with this library is via NuGet packages:

```
> Install-Package omise
```

### Manually

Or you can compile this library manually and add a reference to Omise.Net.dll. The library
also depends on the following packages/assemblies:

* Microsoft.Threading.Tasks (via Microsoft.Async package)
* System.Net.Http (via Microsoft.Net.Http package)

# TLS configuration

If you are using .NET 4.0 or 4.5 and found that the Opn Payments API constantly terminates the
connection causing an exception to be raised, this may be because the platform is using
an unsupported or insecure version of the TLS connection.

You can workaround this by **upgrading to .NET 4.6** or add the following code to the
start of your program:

```csharp
System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocol.Tls12;
```

If your target platform does not have the `ServicePointManager` class, then this library
will not work for you. You will have to find other ways of connecting to the Opn Payments API
securely.

# Getting started

The core of the library is the **client** that contains services to call the APIs. To
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

You may also specify the specific API version to use:

```c#
var client = new Omise.Client([YOUR_PUBLIC_KEY], [YOUR_SECRET_KEY]);
client.APIVersion = "2014-07-27";
```

### Using with ASP.NET Web Forms

Since this library makes extensive use of the async/await C# language feature, you may
want to check out Microsoft's guide on [Using Asynchronous Methods in ASP.NET
4.5](http://www.asp.net/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45)
before using this library.

In a nutshell, your ASP.NET Web Forms page that interacts with the Opn Payments API will need an
`Async="true"` setting on the `@Page` directive:

```aspx
<%@ Page Async="true" ... %>
```

And methods that use async/await must now be registered:

```cs
protected void Page_Load(object sender, EventArgs e)
{
    RegisterAsyncTask(new PageAsyncTask(createCharge));
}

private async Task createCharge()
{
    var omise = new Client(skey: "skey_test_123");

    var charge = await omise.Charges.Create(new Omise.Models.CreateChargeRequest
    {
        Amount = 10025,
        Currency = "THB",
        Card = Request.Form["omiseToken"]
    });

    lblCharge.Text = charge.Id;
}
```

# Development/testing

All tests in this library are against fixture files. There is no network test implemented.
Since we target the PCL even for the test code, the fixture data files are imported as
C# byte slices via a T4 template.

# Tasks

The following example code demonstrates common tasks that you can perform with this package.
Note that, despite this library allowing you to do so, you should never transmit
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

The API calls return `Task<TResult>` so if your development platforms support C#'s
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

### Transferring money to the default Recipient

```c#
var transfer = await Client.Transfers.Create(new CreateTransferRequest
    {
        Amount = 1000000 // 10,000.00 THB
    });

Print("created transfer: {0}", transfer.Id);
```

### Transferring money to a new Recipient

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

# Important note about merchant compliance

Card data should never transit through your server. This library provides the means to create
card tokens server-side but should only be used for testing or if you currently have valid
PCI-DSS Attestation of Compliance (AoC) delivered by a certified QSA Auditor

Instead, we recommend that you follow our guide on how to safely [collect credit card
information](https://docs.opn.ooo/collecting-card-information)

# License

MIT, See [LICENSE](https://github.com/omise/omise-dotnet/blob/master/LICENSE)
file for the full text.
