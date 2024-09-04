﻿using System;
using Omise.Models;

namespace Omise.Resources
{
    public class TransferResource : BaseResource<Transfer>,
    IListable<Transfer>,
    IListRetrievable<Transfer>,
    ICreatable<Transfer, CreateTransferRequest>,
    IDestroyable<Transfer>,
    ISearchable<Transfer>
    {
        public readonly TransferScheduleResource Schedules;

        public SearchScope Scope => SearchScope.Transfer;

        public TransferResource(IRequester requester)
            : base(requester, Endpoint.Api, "/transfers")
        {
            Schedules = new TransferScheduleResource(requester);
        }
    }
}