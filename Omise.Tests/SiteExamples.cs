using System.Linq;
using NUnit.Framework;
using Omise.Models;

namespace Omise.Tests {
    [TestFixture, Ignore]
    public class SiteExamples : OmiseTest {
        Client Client {
            get { return new Client(DummyCredentials); }
        }

        [Test]
        public async void AccountsRetrieveRetrieve() {
            var account = await Client.Account.Get();
            Assert.AreEqual("omise@chakrit.net", account.Email);
        }

        [Test]
        public async void BalancesRetrieveRetrieve() {
            var balance = await Client.Balance.Get();
            Assert.AreEqual(16309324, balance.Available);
        }

        [Test]
        public async void CardsDestroyDestroy() {
            var card = await Client.Cards
                .ByCustomer("cust_test_52ydv7e3ao0oqwjj97e")
                .Destroy("card_test_52ydv7hs189gc7pp752");

            Assert.IsTrue(card.Deleted);
        }

        [Test]
        public async void CardsListList() {
            var cards = await Client.Cards
                .ByCustomer("cust_test_52ydv7e3ao0oqwjj97e")
                .GetList();

            var card = cards.First(c => c.Id == "card_test_52ydv7jkwu6rp6qt96m");
            Assert.AreEqual("Visa", card.Brand);
            Assert.AreEqual("4242", card.LastDigits);
        }

        [Test]
        public async void CardsRetrieveRetrieve() {
            var card = await Client.Cards
                .ByCustomer("cust_test_52ydv7e3ao0oqwjj97e")
                .Get("card_test_52ydv7jkwu6rp6qt96m");

            Assert.AreEqual("Visa", card.Brand);
            Assert.AreEqual("4242", card.LastDigits);
        }

        [Test]
        public async void CardsUpdateUpdate() {
            var update = new UpdateCardRequest {
                Name = "Somchai Prasert",
                ExpirationMonth = 8,
                ExpirationYear = 2017,
            };

            var card = await Client.Cards
                .ByCustomer("cust_test_52ydv7e3ao0oqwjj97e")
                .Update("card_test_52ydv7jkwu6rp6qt96m", update);

            Assert.AreEqual(2017, card.ExpirationYear);
            Assert.AreEqual(8, card.ExpirationMonth);
        }

        [Test]
        public async void ChargesCaptureCapture() {
            var charge = await Client.Charges.Capture("chrg_test_52ydura2lmcryh1b15v");
            Assert.IsTrue(charge.Paid);
        }

        [Test]
        public async void ChargesCreateCreateWithCard() {
            var request = new CreateChargeRequest {
                Amount = 100000, // THB 1,000.00
                Currency = "THB",
                Customer = "cust_test_52ydv7e3ao0oqwjj97e",
                Card = "card_test_52ydv7jkwu6rp6qt96m",
            };

            var charge = await Client.Charges.Create(request);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async void ChargesCreateCreateWithCustomer() {
            var request = new CreateChargeRequest {
                Amount = 100000, // THB 1,000.00
                Currency = "THB",
                Customer = "cust_test_52ydv7e3ao0oqwjj97e",
            };

            var charge = await Client.Charges.Create(request);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async void ChargesCreateCreateWithToken() {
            var request = new CreateChargeRequest {
                Amount = 100000, // THB 1,000.00
                Currency = "THB",
                Card = "tokn_test_4xs9408a642a1htto8z",
            };

            var charge = await Client.Charges.Create(request);
            Assert.AreEqual(100000, charge.Amount);
        }

        [Test]
        public async void ChargesListList() {
            var charges = await Client.Charges.GetList(order: Ordering.ReverseChronological);

            var charge = charges.First(c => c.Id == "chrg_test_52ydurgt5nhckrxbvxh");
            Assert.AreEqual(409669, charge.Amount);
            Assert.IsTrue(charge.Paid);
        }

        [Test]
        public async void ChargesRetrieveRetrieve() {
            var charge = await Client.Charges.Get("chrg_test_52ydurgt5nhckrxbvxh");
            Assert.AreEqual(409669, charge.Amount);
            Assert.IsTrue(charge.Paid);
        }

        [Test]
        public async void ChargesUpdateUpdateDescription() {
            var request = new UpdateChargeRequest {
                Description = "Updated Description",
            };

            var charge = await Client.Charges.Update("chrg_test_52ydurgt5nhckrxbvxh", request);
            Assert.AreEqual(request.Description, charge.Description);
        }

        [Test]
        public async void CustomersCreateAttachCard() {
            var request = new CreateCustomerRequest {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
                Card = "tokn_test_4xs9408a642a1htto8z",
            };

            var customer = await Client.Customers.Create(request);
            Assert.AreEqual(request.Description, customer.Description);
        }

        [Test]
        public async void CustomersCreateCreateSimple() {
            var request = new CreateCustomerRequest {
                Email = "john.doe@example.com",
                Description = "John Doe (id: 30)",
            };

            var customer = await Client.Customers.Create(request);
            Assert.AreEqual(request.Description, customer.Description);
        }

        [Test]
        public async void CustomersDestroyDestroy() {
            var customer = await Client.Customers.Destroy("cust_test_52yefu1m9tvlzertvik");
            Assert.IsTrue(customer.Deleted);
        }

        [Test]
        public async void CustomersListList() {
            var customers = await Client.Customers.GetList(order: Ordering.ReverseChronological);

            var customer = customers.First(c => c.Email == "john.doe@example.com");
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async void CustomersRetrieveRetrieve() {
            var customer = await Client.Customers.Get("cust_test_52ydv7e3ao0oqwjj97e");
            Assert.AreEqual("John Doe (id: 30)", customer.Description);
        }

        [Test]
        public async void CustomersUpdateAttachCard() {
            var customer = await Client.Customers.Get("cust_test_52ydv7e3ao0oqwjj97e");
            var request = new UpdateCustomerRequest {
                Card = "tokn_test_4xs9408a642a1htto8z",
            };

            var updated = await Client.Customers.Update("cust_test_52ydv7e3ao0oqwjj97e", request);
            Assert.AreNotEqual(customer.DefaultCard, updated.DefaultCard);
        }

        [Test]
        public async void CustomersUpdateUpdateSimple() {
            var request = new UpdateCustomerRequest {
                Email = "john.smith@example.com",
                Description = "Updated Description",
            };

            var customer = await Client.Customers.Update("cust_test_52ydv7e3ao0oqwjj97e", request);
            Assert.AreEqual(request.Description, customer.Description);
        }

        [Test]
        public async void DisputesClosedClosed() {
            var disputes = await Client.Disputes.ClosedDisputes.GetList();

            var dispute = disputes.First(d => d.Id == "dspt_test_52yekjurvozldkqyegh");
            Assert.AreEqual(204842, dispute.Amount);
            Assert.AreEqual(DisputeStatus.Lost, dispute.Status);
        }

        [Test]
        public async void DisputesListList() {
            var disputes = await Client.Disputes.GetList();

            var dispute = disputes.First(d => d.Id == "dspt_test_52yem1zeuw5nq8yrw29");
            Assert.AreEqual(204842, dispute.Amount);
            Assert.AreEqual(DisputeStatus.Open, dispute.Status);
        }

        [Test]
        public async void DisputesOpenOpen() {
            var disputes = await Client.Disputes.OpenDisputes.GetList();

            var dispute = disputes.First(d => d.Id == "dspt_test_52yem1zeuw5nq8yrw29");
            Assert.AreEqual(204842, dispute.Amount);
            Assert.AreEqual(DisputeStatus.Open, dispute.Status);
        }

        [Test]
        public async void DisputesPendingPending() {
            var disputes = await Client.Disputes.PendingDisputes.GetList();

            var dispute = disputes.First(d => d.Id == "dspt_test_52yem1zeuw5nq8yrw29");
            Assert.AreEqual(204842, dispute.Amount);
            Assert.AreEqual(DisputeStatus.Pending, dispute.Status);
        }

        [Test]
        public async void DisputesRetrieveRetrieve() {
            var dispute = await Client.Disputes.Get("dspt_test_52yem1zeuw5nq8yrw29");
            Assert.AreEqual(204842, dispute.Amount);
            Assert.AreEqual(DisputeStatus.Pending, dispute.Status);
        }

        [Test]
        public async void DisputesUpdateUpdate() {
            var request = new UpdateDisputeRequest {
                Message = "Hello World!",
            };

            var dispute = await Client.Disputes.Update("dspt_test_52yenqb8ue6giglkwl1", request);
            Assert.AreEqual(dispute.Message, request.Message);
        }

        [Test]
        public async void RecipientsCreateCreate() {
            var request = new CreateRecipientRequest {
                Name = "Somchai Prasert",
                Email = "somchai.prasert@example.com",
                Type = RecipientType.Individual,
                BankAccount = new BankAccountRequest {
                    Brand = "bbl",
                    Number = "12345",
                    Name = "SOMCHAI PRASERT",
                },
            };

            var recipient = await Client.Recipients.Create(request);
            Assert.AreEqual(request.Name, recipient.Name);
            Assert.AreEqual(request.BankAccount.Name, recipient.BankAccount.Name);
        }

        [Test]
        public async void RecipientsDestroyDestroy() {
            var recipient = await Client.Recipients.Destroy("recp_test_52yeozzqxjn3gak57rt");
            Assert.IsTrue(recipient.Deleted);
        }

        [Test]
        public async void RecipientsListList() {
            var recipients = await Client.Recipients.GetList();

            var recipient = recipients.First(r => r.Id == "recp_test_52yeov3bkjqpun3b4sm");
            Assert.AreEqual("Somchai Prasert", recipient.Name);
        }

        [Test]
        public async void RecipientsRetrieveRetrieve() {
            var recipient = await Client.Recipients.Get("recp_test_52yeov3bkjqpun3b4sm");
            Assert.AreEqual("Somchai Prasert", recipient.Name);
        }

        [Test]
        public async void RecipientsUpdateUpdate() {
            var request = new UpdateRecipientRequest {
                Email = "somchai@prasert.com",
                BankAccount = new BankAccountRequest {
                    Brand = "kbank",
                    Number = "1234567890",
                    Name = "SOMCHAI PRASERT",
                },
            };

            var recipient = await Client.Recipients.Update("recp_test_52yeov3bkjqpun3b4sm", request);
            Assert.AreEqual(request.BankAccount.Brand, recipient.BankAccount.Brand);
        }

        [Test]
        public async void RefundsCreateCreate() {
            var request = new CreateRefundRequest {
                Amount = 100000, // THB 1,000.00
            };

            var refund = await Client.Refunds
                .ByCharge("chrg_test_52ye6ksqi1dacbw8wkx")
                .Create(request);

            Assert.AreEqual(100000, refund.Amount);
        }

        [Test]
        public async void RefundsListList() {
            var refunds = await Client.Refunds
                .ByCharge("chrg_test_52ye6ksqi1dacbw8wkx")
                .GetList();

            var refund = refunds.First(r => r.Id == "rfnd_test_52yerwurrqdzlm7fkuz");
            Assert.AreEqual(100000, refund.Amount);
        }

        [Test]
        public async void RefundsRetrieveRetrieve() {
            var refund = await Client.Refunds
                .ByCharge("chrg_test_52ye6ksqi1dacbw8wkx")
                .Get("rfnd_test_52yerwurrqdzlm7fkuz");

            Assert.AreEqual(100000, refund.Amount);
        }

        [Test]
        public async void TokensCreateCreate() {
            var request = new CreateTokenRequest {
                Name = "Somchai Prasert",
                Number = "4242424242424242",
                ExpirationMonth = 10,
                ExpirationYear = 2018,
                City = "Bangkok",
                PostalCode = "10320",
                SecurityCode = "123",
            };

            var token = await Client.Tokens.Create(request);
            Assert.AreEqual("4242", token.Card.LastDigits);
            Assert.AreEqual("Visa", token.Card.Brand);
            Assert.IsFalse(token.Used);
        }

        [Test]
        public async void TokensRetrieveRetrieve() {
            var token = await Client.Tokens.Get("tokn_test_52yeu9ez3ybyogkirwj");
            Assert.AreEqual("4242", token.Card.LastDigits);
            Assert.AreEqual("Visa", token.Card.Brand);
            Assert.IsFalse(token.Used);
        }

        [Test]
        public async void TransactionsListList() {
            var transactions = await Client.Transactions.GetList();

            var transaction = transactions.First(t => t.Id == "trxn_test_52q4re5i1gjt13kavur");
            Assert.AreEqual(TransactionType.Credit, transaction.Type);
            Assert.AreEqual(196842, transaction.Amount);
        }

        [Test]
        public async void TransactionsRetrieveRetrieve() {
            var transaction = await Client.Transactions.Get("trxn_test_52q4re5i1gjt13kavur");
            Assert.AreEqual(TransactionType.Credit, transaction.Type);
            Assert.AreEqual(196842, transaction.Amount);
        }

        [Test]
        public async void TransfersCreateCreate() {
            var request = new CreateTransferRequest {
                Amount = 100000
            };

            var transfer = await Client.Transfers.Create(request);
            Assert.AreEqual(100000, transfer.Amount);
        }

        [Test]
        public async void TransfersCreateCreateWithRecipient() {
            var request = new CreateTransferRequest {
                Amount = 100000,
                Recipient = "recp_test_52yeov3bkjqpun3b4sm",
            };

            var transfer = await Client.Transfers.Create(request);
            Assert.AreEqual(100000, transfer.Amount);
            Assert.AreEqual(request.Recipient, transfer.Recipient);
        }

        [Test]
        public async void TransfersDestroyDestroy() {
            var transfer = await Client.Transfers.Destroy("trsf_test_52yew5v158k3d4awmu2");
            Assert.IsTrue(transfer.Deleted);
        }

        [Test]
        public async void TransfersListList() {
            var transfers = await Client.Transfers.GetList();

            var transfer = transfers.First(t => t.Id == "trsf_test_52yew5v158k3d4awmu2");
            Assert.AreEqual(100000, transfer.Amount);
        }

        [Test]
        public async void TransfersRetrieveRetrieve() {
            var transfer = await Client.Transfers.Get("trsf_test_52yew5v158k3d4awmu2");
            Assert.AreEqual(100000, transfer.Amount);
        }

        [Test]
        public async void TransfersUpdateUpdate() {
            var request = new UpdateTransferRequest {
                Amount = 50000, // THB 500.00
            };

            var transfer = await Client.Transfers.Update("trsf_test_52yew5v158k3d4awmu2", request);
            Assert.AreEqual(50000, transfer.Amount);
        }
    }
}