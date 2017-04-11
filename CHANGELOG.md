# CHANGE LOG

# v2.4.2

* Add newly available search scopes.

# v2.4.1

* Fix enum serialization with `[EnumMember(Value=null)]` not working correctly as intended.

# v2.4.0

* Adds support for the new [Internet Banking](https://www.omise.co/internet-banking-is-now-live)
  payment channel

# v2.3.0

* Allows `expiration_month` and `expiration_year` to be null.

# v2.2.0

* Adds support for the new Link API.
* Upgrade test suites to NUnit 3.5

# v2.1.0

* Adds support for the newly released Search API.
* Retarget to .NET 4.0 (previously 4.0.3)
* Upgrade test suites to NUnit 3.4.1

# v2.0.9

* Adds missing `reversed` charge status.

# v2.0.8

* Adds missing `void` parameter for Refund API.

# v2.0.7

* Adds new `client.Charges.Reverse` API method.

# v2.0.6

* Adds new `Charge.reversed` field.

# v2.0.5

* Upgrade Newtonsoft.JSON to 8.0.3
* Adds missing `Client.APIVersion` setting (mistakenly left out).
* Adds missing `ScopedList.Location` field.

# v2.0.4

* Correct dependency list in nuspec.

# v2.0.3

* Fix wrong `Newtonsoft.Json` dependency version.

# v2.0.2

* Fix wrong `order` parameter serialization.

# v2.0.1

* Update new/removed model fields.

# v2.0.0

* Rewrite while maintaining similar API surface.
* Drops pre-4.0 support. (v1.0 is still available for that.)
* Targets Mono/PCL for maximum portability.

### Pre-2.0

See [v1.0 change logs](https://github.com/omise/omise-dotnet/blob/v1.0/CHANGELOG.md) for
more information.
