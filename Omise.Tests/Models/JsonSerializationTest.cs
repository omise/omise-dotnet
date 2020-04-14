using System;
using System.IO;
using NUnit.Framework;
using Omise.Models;
using Omise.Tests.Util;

namespace Omise.Tests.Models
{
    [TestFixture]
    public class JsonSerializationTest : OmiseTest
    {
        // TODO: Add Link, Schedule and other things.
        static readonly Type[] modelTypes = {
            typeof(Account),
            typeof(Balance),
            typeof(BankAccount),
            typeof(Barcode),
            typeof(Card),
            typeof(Charge),
            typeof(Customer),
            typeof(Document),
            typeof(Dispute),
            typeof(Event),
            typeof(Recipient),
            typeof(Refund),
            typeof(Token),
            typeof(Transaction),
            typeof(Transfer)
        };

        [Test]
        public void TestJsonSerialize()
        {
            var serializer = new Serializer();
            foreach (var type in modelTypes)
            {
                var method = serializer
                    .GetType()
                    .GetMethod("JsonSerialize")
                    .MakeGenericMethod(type);

                using (var ms = new MemoryStream())
                {
                    var instance = Activator.CreateInstance(type);
                    method.Invoke(serializer, new object[] { ms, instance });
                }
            }
        }

        [Test]
        public void TestJsonDeserialize()
        {
            var serializer = new Serializer();
            foreach (var type in modelTypes)
            {
                var method = serializer
                    .GetType()
                    .GetMethod("JsonDeserialize")
                    .MakeGenericMethod(type);

                var filename = $"{ModelTypes.NameFor(type)}_object.json";
                var fullpath = Fixtures.GetFixturesPath(filename, "objects");

                if (!File.Exists(fullpath))
                {
                    throw new FileNotFoundException(filename);
                }

                var filedata = File.ReadAllBytes(fullpath);

                object result;
                using (var ms = new MemoryStream(filedata))
                {
                    result = method.Invoke(serializer, new object[] { ms });
                }

                Assert.IsInstanceOf(type, result);
            }
        }
    }
}

