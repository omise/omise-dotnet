using System;
using NUnit.Framework;
using Omise.Tests;
using System.IO;
using Omise.Tests.Util;
using System.Dynamic;
using Newtonsoft.Json;

namespace Omise.Tests {
    [TestFixture]
    public class SerializerTest : OmiseTest {
        const string DummyJson =
            "{\"James\":\"Howlett\",\"Scott\":\"Summers\",\"Johny\":\"Mnemonic\"," +
            "\"With\":\"SPACES SPACES\",\"Created\":\"9999-12-31T23:59:59.9999999\"}";
        const string DummyUrlEncoded =
            "James=Howlett&Scott=Summers&Johny=Mnemonic&" +
            "With=SPACES%20SPACES&Created=9999-12-31T23:59:59Z";

        [Test]
        public void TestJsonSerialize() {
            var serializer = new Serializer();
            var dummy = new SerializerTestDummy();

            string result;
            using (var stream = new StringMemoryStream()) {
                serializer.JsonSerialize(stream, dummy);
                result = stream.ToDecodedString();
            }

            Assert.AreEqual(DummyJson, result);
        }

        [Test]
        public void TestJsonDeserialize() {
            var serializer = new Serializer();
            var reference = new SerializerTestDummy();
            var json = DummyJson;

            SerializerTestDummy result;
            using (var stream = new StringMemoryStream(json)) {
                result = serializer.JsonDeserialize<SerializerTestDummy>(stream);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(reference.James, result.James);
            Assert.AreEqual(reference.Scott, result.Scott);
        }

        [Test]
        public void TestFormSerialize() {
            var serializer = new Serializer();
            var dummy = new SerializerTestDummy();

            string result;
            using (var stream = new StringMemoryStream()) {
                serializer.FormSerialize(stream, dummy);
                result = stream.ToDecodedString();
            }
                
            Assert.AreEqual(DummyUrlEncoded, result);
        }
    }

    class SerializerTestDummy {
        public string James { get; set; }
        public string Scott { get; set; }

        [JsonProperty("Johny")]
        public string Aliased { get; set; }

        public string With { get; set; }
        public DateTime Created { get; set; }


        public SerializerTestDummy() {
            James = "Howlett";
            Scott = "Summers";
            With = "SPACES SPACES";
            Created = DateTime.MaxValue;
            Aliased = "Mnemonic";
        }
    }
}

