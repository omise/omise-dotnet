using Omise.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Omise.Examples
{
    public class Links : Example
    {
        public async Task List__List()
        {
            var links = await Client.Links.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total links: {links.Total}");
        }

        public async Task Create__Create_For_Once()
        {
            var link = await Client.Links.Create(new CreateLinkRequest
            {
                Amount = 2000,
                Currency = "thb",
                Title = "that shirt.",
                Description = "that shirt.",
            });

            Console.WriteLine($"payment link: {link.PaymentURI}");
        }

        public async Task Create__Create_For_Multi()
        {
            var link = await Client.Links.Create(new CreateLinkRequest
            {
                Amount = 2000,
                Currency = "thb",
                Title = "that shirt.",
                Description = "that shirt.",
                Multiple = true,
            });

            Console.WriteLine($"payment link: ({link.Multiple}) {link.PaymentURI}");
        }

        public async Task Retrieve__Retrieve()
        {
            var link = await Client.Links.Get(ExampleInfo.LINK_ID);
            Console.WriteLine($"link paid?: {link.Used} {link.Charges.FirstOrDefault()?.Id})");
        }
    }
}
