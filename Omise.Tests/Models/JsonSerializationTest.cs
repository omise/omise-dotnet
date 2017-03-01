using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Omise.Models;

namespace Omise.Tests.Models {
    [TestFixture]
    public class JsonSerializationTest : OmiseTest {
        static readonly Type[] modelTypes = {
            typeof(Account),
            typeof(Balance),
            typeof(BankAccount),
            typeof(Card),
            typeof(Charge),
            typeof(Customer),
            typeof(Dispute),
            typeof(Event),
            typeof(Recipient),
            typeof(Refund),
            typeof(Token),
            typeof(Transaction),
            typeof(Transfer)
        };

        [Test]
        public void TestJsonSerialize() {
            var serializer = new Serializer();
            foreach (var type in modelTypes) {
                var method = serializer
                    .GetType()
                    .GetMethod("JsonSerialize")
                    .MakeGenericMethod(type);

                using (var ms = new MemoryStream()) {
                    var instance = Activator.CreateInstance(type);
                    method.Invoke(serializer, new object[] { ms, instance });
                }
            }
        }

        [Test]
        public void TestJsonDeserialize() {
            var serializer = new Serializer();
            foreach (var type in modelTypes) {
                var method = serializer
                    .GetType()
                    .GetMethod("JsonDeserialize")
                    .MakeGenericMethod(type);

                var filename = $"objects/{ModelTypes.NameFor(type)}_object.json";
                if (!TestData.Files.ContainsKey(filename)) {
                    throw new FileNotFoundException(filename);
                }

                var filedata = TestData.Files[filename];

                object result;
                using (var ms = new MemoryStream(filedata)) {
                    result = method.Invoke(serializer, new object[] { ms });
                }

                Assert.IsInstanceOf(type, result);
            }
        }
    }
}

