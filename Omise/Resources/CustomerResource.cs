using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class CustomerResource : BaseResource<Customer>,
        IDestroyable<Customer>,
        IListable<Customer>,
        IListRetrievable<Customer>,
        IUpdatable<Customer, UpdateCustomerParams>,
        ICreatable<Customer, CreateCustomerParams>,
        ISearchable<Customer>
    {
        public CustomerScheduleResource Schedules { get; private set; }
        public SearchScope Scope => SearchScope.Customer;

        public CustomerResource(IRequester requester)
        : base(requester, Endpoint.Api, "/customers")
        {
        }

        public CustomerResource Customer(string customerId) {
            Schedules = new CustomerScheduleResource(Requester, customerId);

            return this;
        }
    }

    public class CustomerScheduleResource : BaseResource<Schedule>,
        IListable<Schedule>
    {
        public CustomerScheduleResource(IRequester requester, string customerId)
        : base(requester, Endpoint.Api, $"/customers/{customerId}/schedules")
        {
        }
    }
}