# Migration Plan

## Introduction

This guide is to help integrators migrate from v3.x to v4.x

**Overview**:

- **Reason for Upgrade**: Support omise API version 2019-05-29

## Migration Overview

- **Major Changes**:

  - Remove fields from request models
  - Add fields to response models
  - Set fields to nullable in requests where necessary

- **Estimated Effort**: Low

## Breaking Changes

The behavior of the SDK is not affected.

## Deprecated Endpoints

None

## New Endpoints

None

## Request/Response Changes

| **Endpoint**                    | **Request Changes**       | **Response Changes**                                           |
| ------------------------------- | ------------------------- | -------------------------------------------------------------- |
| https://api.omise.co/balance    | None                      | Available => Transferable                                      |
| BankAccount model               | None                      | Number = > AccountNumber                                       |
| https://api.omise.co/charges    | Offsite, Flow => removed  | Refunded => RefundedAmount<br>Offsite, SourceOfFund => removed |
| https://api.omise.co/sources    | Offsite, Flow => removed  | None                                                           |
| AuthTypes enum                  | AuthTypes.None => removed | AuthTypes.None => removed                                      |
| All models using the base model | None                      | Created => CreatedAt                                           |

## Error Handling

None

## Step-by-Step Migration Process

Replace all deprecated/removed response/request parameters with the mentioned replacements.
