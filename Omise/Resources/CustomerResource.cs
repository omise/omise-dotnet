using Omise.Models;

namespace Omise.Resources
{
    public class CustomerResource : BaseResource<Customer>,
    IListable<Customer>,
    IListRetrievable<Customer>,
    ICreatable<Customer, CreateCustomerRequest>,
    IUpdatable<Customer, UpdateCustomerRequest>,
    IDestroyable<Customer>,
    ISearchable<Customer>
    {
        public SearchScope Scope => SearchScope.Customer;

        public CustomerResource(IRequester requester)
            : base(requester, Endpoint.Api, "/customers")
        {
        }
    }
}