# CHANGE LOG

## v3.0.0 ([#77](https://github.com/omise/omise-dotnet/pull/77))

- Added support for dynamic webhooks by adding `webhook_endpoints` in create charge request.
- Added examples and unit tests for dynamic webhooks

## v2.9.0 ([#75](https://github.com/omise/omise-dotnet/pull/75))

- Updated charge models to include `authorization_type` field.
- Added support for partial capture by adding `capture_amount` in capture request.
- Added examples and unit tests for partial capture

## v2.8.0 ([#73](https://github.com/omise/omise-dotnet/pull/73))

- Updated charge models to include `expired_at` field.
- Added `.example.env` and moved from static exposed values to `.env` usage
- Changed unit testing to `dotnet test` instead of `nunit3-console.exe` removing third party dependency

## v2.7.14

* Updated charge models to include `paid_at` field.

## v2.7.13

* Added new payment source `OCBC Pay Anyone`.

## v2.7.12

* Added source types for Alipay+
  - `AlipayCN`
  - `AlipayHK`
  - `GANA`
  - `GCash`
  - `KakaoPay`
  - `TouchNGo`

## v2.7.11

* Added `RabbitLinepay` source types.

## v2.7.10

* Added `InstallmentSCB` and `InstallmentCiti` source types.

## v2.7.9

* Fixed missing `PhoneNumber` attribute for `truemoney` payment source.

## v2.7.8

* Added new payment source `promptpay`.

## v2.7.7

* Added `PaymentSource.scannable_code`, `Document` and `Barcode`.

## v2.7.6

* Added new payment sources (e.g. paynow, truemoney, etc.)

## v2.7.5

* Fixed bug for nuget packaging + netstandard 2.0 produces large package

## v2.7.4

* Added FirstDigits field to Cards.

## v2.7.3

* Supported for charge expire api.

## v2.7.2

* Added expired in charge status.

## v2.7.1

* Update nuget packages.

## v2.7.0

* Supported Alipay barcode.

## v2.6.0

* **NEW:** Internet Banking API.
* **NEW:** Bill Payment API.

## v2.5.6

* **NEW:** Receipts API.

## v2.5.5

* **FIXED:** Calling `.Equals` on model objects to compare it with an object of
  incompatible types will throw `InvalidCastException`.
* **FIXED:** Forex API was added, but not accessible from the `Client`.
* **FIXED:** Occurrences listings on ScheduleSpecificResource has wrong listable type.
  Should implements `IListable`.
* **FIXED:** Transfer schedule resource was not properly initialized on the base resource.
* **FIXED:** Transfer schedule params send a default of 0.0 when not set. Amount and
  PercentageOfBalance properties are now nullable.
* **UPDATED:** Newtonsoft.JSON to 10.0.3 and NuGet.Build.Packaging to 0.1.323

## v2.5.4

* **NEW:** Transfer schedule APIs.
* **FIXED:** There is no `currency` field on TransferScheduling, it has been removed.
* **FIXED:** `Charges.Schedules` resource previously returns wrong type `Charge` (should be
  `Schedule`)

## v2.5.3

* **FIXED:** `installment_terms` are sent as `0` when not set. It is now changed to a
  nullable field.

## v2.5.2

Skipped to maintain parity with omise-java.

## v2.5.1

* **NEW:** `Schedule.charge.description` attribute.
* **NEW:** [Installments](https://www.omise.co/installment-payment).
* **NEW:** Fail-fast transfers.

## v2.5.0

* **CHANGED:** Library now targets .NET Standard 1.2 instead of the PCL.
* **CHANGED:** Library is now built with Visual Studio for Mac 2017
* **CHANGED:** Library now sends data in JSON format instead of form-data.
* **CHANGED:** Resources with parent-child relationship such as Refunds which are
  Charge-specific are now accessed through a new `client.Charge("chrg_id")` method.
* **FIXED:** GetHashCode() on models now handles nulls correctly.
* **NEW:** Schedules API.
* **NEW:** Forex API.
* **NEW:** Metadata API for Charge and Customer.
* **NEW:** Refund, Transfer and Link can now be searched.
* **NEW:** Miscellaneous additions to existing APIs.

## v2.4.2

* Add newly available search scopes.

## v2.4.1

* Fix enum serialization with `[EnumMember(Value=null)]` not working correctly as intended.

## v2.4.0

* Adds support for the new [Internet Banking](https://www.omise.co/internet-banking-is-now-live)
  payment channel

## v2.3.0

* Allows `expiration_month` and `expiration_year` to be null.

## v2.2.0

* Adds support for the new Link API.
* Upgrade test suites to NUnit 3.5

## v2.1.0

* Adds support for the newly released Search API.
* Retarget to .NET 4.0 (previously 4.0.3)
* Upgrade test suites to NUnit 3.4.1

## v2.0.9

* Adds missing `reversed` charge status.

## v2.0.8

* Adds missing `void` parameter for Refund API.

## v2.0.7

* Adds new `client.Charges.Reverse` API method.

## v2.0.6

* Adds new `Charge.reversed` field.

## v2.0.5

* Upgrade Newtonsoft.JSON to 8.0.3
* Adds missing `Client.APIVersion` setting (mistakenly left out).
* Adds missing `ScopedList.Location` field.

## v2.0.4

* Correct dependency list in nuspec.

## v2.0.3

* Fix wrong `Newtonsoft.Json` dependency version.

## v2.0.2

* Fix wrong `order` parameter serialization.

## v2.0.1

* Update new/removed model fields.

## v2.0.0

* Rewrite while maintaining similar API surface.
* Drops pre-4.0 support. (v1.0 is still available for that.)
* Targets Mono/PCL for maximum portability.

### Pre-2.0

See [v1.0 change logs](https://github.com/omise/omise-dotnet/blob/v1.0/CHANGELOG.md) for
more information.
