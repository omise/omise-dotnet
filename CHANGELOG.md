# Change Log

An [unreleased] version is not available on nuget and is subject to changes and must not be considered final. Elements of unreleased list may be edited or removed at any time.
## [unreleased] 2015-11-04

- [Added] Ability to specify Api Version on Client
- [Added] Add new "Status" string property to Charge. The possible values are Pending, Successful or Failed.
- [Added] Add new "Paid" boolean property to Charge. The value indicates that a charge was paid (or captured). 
- [Added] Add new "Bank" string property to Card. The value represents the card issuer.

## [1.0.6] 2015-06-04

- [Added] Add 'GetAllCustomers' and 'GetAllCharges'
- [Added] Add Recipients api
- [Added] Add Disputes api
- [Added] Add Transfer to recipient

## [1.0.5] 2015-04-17

- [Changed] Cast WebRequest to HttpWebRequest in order to pass the user-agent http header
- [Added] Add 'user-agent' http header to the request manager
- [Added] Add VersionInfo object for getting the version information

## [1.0.4] 2015-03-31

- [Added] Add the refunds detail to Charge model. 
- [Added] Add the Capture method to ChargeService to allow manually capture a charge.

## [1.0.3] - 2015-03-18

- [Fixed] Fix create customer card exception
- [Changed] Make ReturnUri not mandatory when creating a charge

## [1.0.2] - 2015-03-06

- [Fixed] Fix incorrect assembly version on nuget

## [1.0.1] - 2015-02-02

- [Fixed] Fix create customer card error
- [Added] Add service method for setting the customer's default card

## [1.0.0] - 2015-01-30

- Initial version.
