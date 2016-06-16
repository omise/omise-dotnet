using System;

namespace Omise.Example {
    class MainClass {
        public static void Main(string[] args) {
            var ex = new AccountBalanceExample();

            try {
                ex.Run().Wait();
            }
            catch (Exception e) {
                Console.Error.WriteLine(e);
            }
        }
    }
}