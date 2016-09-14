using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Omise.Example {
    public class SearchExample : Example {
        public override async Task Run() {
            var result = await Client.Charges.Search(filters: new Dictionary<string, string> {
                { "amount", "4096.69" }
            });

            Print("total pages: {0}", result.TotalPages);
            Print("first page:  {0}", result.Count);
            foreach (var entry in result) {
                Print(entry.Id);
            }
        }
    }
}

