# OMISE-DOTNET

[![NuGet](https://img.shields.io/nuget/v/Omise.svg?style=flat-square)](https://www.nuget.org/packages/Omise/)
[![Build Status](https://img.shields.io/travis/omise/omise-dotnet.svg?style=flat-square)](https://travis-ci.org/omise/omise-dotnet)
[![](https://img.shields.io/badge/discourse-forum-1a53f0.svg?style=flat-square&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAAXNSR0IArs4c6QAAAAlwSFlzAAALEwAACxMBAJqcGAAAAVlpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IlhNUCBDb3JlIDUuNC4wIj4KICAgPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICAgICAgPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIKICAgICAgICAgICAgeG1sbnM6dGlmZj0iaHR0cDovL25zLmFkb2JlLmNvbS90aWZmLzEuMC8iPgogICAgICAgICA8dGlmZjpPcmllbnRhdGlvbj4xPC90aWZmOk9yaWVudGF0aW9uPgogICAgICA8L3JkZjpEZXNjcmlwdGlvbj4KICAgPC9yZGY6UkRGPgo8L3g6eG1wbWV0YT4KTMInWQAAAqlJREFUKBU9UVtLVFEU%2FvY%2B27mPtxl1dG7HbNRx0rwgFhJBPohBL9JTZfRQ0YO9RU%2FVL6iHCIKelaCXqIewl4gEBbEyxSGxzKkR8TbemmbmnDlzVvsYtOHbey1Y317fWh8DwCVMCfSHww3ElCs7CjuzbOcNIaEo9SbtlDRjZiNPY%2BvrqSWrTh7l3yPvrmh0KBZW59HcREjEqcGpElAuESRxopU648dTwfrIyH%2BCFXSH1cFgJLqHlma6443SG0CfqYY2NZjQnkV8eiMgP6ijjnizHglErlocdl5VA0mT3v102dseL2W14cYM99%2B9XGY%2FlQArd8Mo6JhbSJUePHytvf2UdnW0qen93cKQ4nWXX1%2FyOkZufsuZN0L7PPzkthDDZ4FQLajSA6XWR8HWIK861sCfj68ggGwl83mzfMclBmAQ%2BktrqBu9wOhcD%2BB0ErSiFFyEkdcYhKD27mal9%2F5FY36b4BB%2FTvO8XdQhlUe11F3WG2fc7QLlC8wai3MGGQCGDkcZQyymCqAPSmati3s45ygWseeqADwuWS%2F3wGS5hClDMMstxvJFHQuGU26yHsY6iHtL0sIaOyZzB9hZz0hHZW71kySSl6LIJlSgj5s5LO6VG53aFgpOfOFCyoFmYsOS5HZIaxVwKYsLSbJJn2kfU%2BlNdms5WMLqQRklX0FX26eFRnKYwzX0XRsgR0uUrWxplM7oqPIq8r8cZrdLNLqaABayxZMTTx2HVfglbP4xkcvqZEMNfmglevRi1ny5mGfJfTuQiBEq%2FMBvG0NqDh2TY47sbtJAuO%2Fe9%2Fn3STRFosm2WIxsFSFrFUfwHb11JNBNcaZSp8yb%2FEhHW3suWRNZRzDGvxb0oifk5lmnX2V2J2dEJkX1Q0baZ1MvYXPXHvhAga7x9PTEyj8a%2BF%2BXbxiTn78bSQAAAABJRU5ErkJggg%3D%3D)](https://forum.omise.co)

**This library has been updated to v2.0, check the v1 branch for the previous version.**

Omise.Net is a NuGet package for CLR platforms (.NET/Mono) written in C#. This package
provides a set of bindings to the [Omise REST API](https://www.omise.co/docs).

Please pop onto our [gitter chat](https://gitter.im/omise/omise-dotnet) or contact
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

# TLS CONFIGURATION

If you are using .NET 4.0 or 4.5 and found that Omise API constantly terminates the
connection causing an exception to be raised., this may be because the platform is using
an unsupported or insecure version of the TLS connection.

You can workaround this by **upgrading to .NET 4.6** or add the following code to the
start of your program:

```csharp
System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocol.Tls12;
```

If your target platform do not have the `ServicePointManager` class, then this library
will not work for you and you will have to find other means of connecting to the Omise API
securely.

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

### Using with ASP.NET Web Forms

Since this library makes extensive use of the async/await C# language feature, you may
want to check out Microsoft's guide on [Using Asynchronous Methods in ASP.NET
4.5](http://www.asp.net/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45)
before you start using this library.

In a nutshell, your ASP.NET Web Forms page that interacts with Omise API will needs an
`Async="true"` setting on `@Page` directive:

```aspx
<%@ Page Async="true" ... %>
```

And methods that uses async/await must now be registered:

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
