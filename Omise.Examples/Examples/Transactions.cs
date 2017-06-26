using Omise.Models;
using System.Threading.Tasks;
using System;

namespace Omise.Examples.Examples
{
    public class Transactions : Example
    {
        public async Task List_List()
        {
            var transactions = await Client.Transactions.GetList(order: Ordering.ReverseChronological);
            Console.WriteLine($"total transactions to-date: {transactions.Total}");
        }

        public async Task Retrieve_Retrieve()
        {
            var transactionId = "trxn_test_58fmj4hion95mndc96d";
            var transaction = await Client.Transactions.Get(transactionId);
            Console.WriteLine($"transaction amount: {transaction.Amount}");
        }
    }
}
