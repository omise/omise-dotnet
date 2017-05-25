using System;
using System.Collections.Generic;
using System.Linq;
using Omise.Models;

namespace Omise.Example.ViewModels.Charges
{
    public class Index : ViewModel
    {
        public IEnumerable<Charge> Charges { get; set; }

        public Index()
        {
            Charges = Enumerable.Empty<Charge>();
        }
    }
}
