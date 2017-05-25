using System.IO;
using System.Text;
using NUnit.Framework;
using Omise.Models;

namespace Omise.Tests.Models
{
    public class EventTest
    {
        [Test]
        public void TestJsonDeserialize()
        {
            const string JSON = @"
                { ""key"": ""customer.update""
                , ""data"":
                    { ""object"": ""customer""
                    , ""id"": ""cust_test_321""
                    }
                }
                ";

            Event result;

            var bytes = Encoding.UTF8.GetBytes(JSON);
            using (var stream = new MemoryStream(bytes))
            {
                result = new Serializer().JsonDeserialize<Event>(stream);
            }

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Customer>(result.Data);
            Assert.AreEqual("cust_test_321", result.Data.Id);
        }
    }
}

