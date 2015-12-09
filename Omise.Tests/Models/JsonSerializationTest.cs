using System;
using NUnit.Framework;
using System.Collections;
using Omise.Models;
using Omise.Tests;
using System.Collections.Generic;
using Newtonsoft.Json.Schema;
using System.IO;

namespace Omise.Tests.Models {
    [TestFixture]
    public class JsonSerializationTest : OmiseTest {
        static readonly IDictionary<byte[], Type> mappings = new Dictionary<byte[], Type>
        {
            { TestData.Objects.account_object_json, typeof(Account) },
            { TestData.Objects.balance_object_json, typeof(Balance) },
            { TestData.Objects.bank_account_object_json, typeof(BankAccount) },
            { TestData.Objects.card_object_json, typeof(Card) },
            { TestData.Objects.charge_object_json, typeof(Charge) },
            { TestData.Objects.customer_object_json, typeof(Customer) },
            { TestData.Objects.dispute_object_json, typeof(Dispute) },
            { TestData.Objects.event_object_json, typeof(Event) },
            { TestData.Objects.recipient_object_json, typeof(Recipient) },
            { TestData.Objects.refund_object_json, typeof(Refund) },
            { TestData.Objects.token_object_json, typeof(Token) },
            { TestData.Objects.transaction_object_json, typeof(Transaction) },
            { TestData.Objects.transfer_object_json, typeof(Transfer) },
        };

        [Test]
        public void TestJsonSerialize() {
            var serializer = new Serializer();
            foreach (var pair in mappings) {
                var type = pair.Value;
                var method = serializer.GetType().GetMethod("JsonSerialize");
                method = method.MakeGenericMethod(type);

                using (var ms = new MemoryStream()) {
                    var instance = Activator.CreateInstance(type);
                    method.Invoke(serializer, new object[] { ms, instance });
                }

                // TODO: Actually test serialized data.
            }
        }

        [Test]
        public void TestJsonDeserialize() {
            var serializer = new Serializer();
            foreach (var pair in mappings) {
                var bytes = pair.Key;
                var type = pair.Value;

                var method = serializer.GetType().GetMethod("JsonDeserialize");
                method = method.MakeGenericMethod(type);

                object result;   
                using (var ms = new MemoryStream(bytes)) {
                    result = method.Invoke(serializer, new object[]{ ms });
                }

                Assert.IsInstanceOf(type, result);
                // TODO: Actually assert that correct data is serialized.
            }
        }
    }
}

