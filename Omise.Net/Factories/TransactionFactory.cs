using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omise
{
    /// <summary>
    /// Factory object defines methods for creating transaction object from api response
    /// </summary>
    public class TransactionFactory : GenericFactory<Transaction>
    {
        /// <summary>
        /// Initialize the factory
        /// </summary>
        public TransactionFactory()
        {
        }
    }
}

