using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples
{
    public class Transactions : Example
    {
        public async Task List__List()
        {
            var transactions = await Client.Transactions.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total transactions to-date: {transactions.Total}");
        }

        public async Task Retrieve__Retrieve()
        {
            var transactionId = ExampleInfo.TRANSACTION_ID; // "trxn_test_5aasqmjqoyd3cpq1koo";
            var transaction = await Client.Transactions.Get(transactionId);
            Console.WriteLine($"transaction amount: {transaction.Amount}");
        }
    }
}
