using System;
using NUnit.Framework;
using Omise.Tests;
using System.IO;
using Omise.Tests.Util;
using System.Dynamic;
using Newtonsoft.Json;
using Omise.Models;
using System.Reflection;
using System.Runtime.Serialization;

namespace Omise.Tests {
    [TestFixture]
    public class SerializerTest : OmiseTest {
        const string DummyJson =
            "{\"james\":\"Howlett\",\"scott\":\"Summers\",\"johny\":\"Mnemonic\"," +
            "\"with\":\"SPACES SPACES\",\"created\":\"9999-12-31T23:59:59.9999999\"," +
            "\"checked\":true,\"enumer\":\"not_exactly_twice\",\"nested\":{\"field\":\"inner\"}}";
        const string DummyUrlEncoded =
            "james=Howlett&scott=Summers&Johny=Mnemonic&" +
            "with=SPACES%20SPACES&created=9999-12-31T23%3A59%3A59Z&" +
            "checked=true&enumer=not_exactly_twice&nested[field]=inner";

        Serializer Serializer { get; set; }
        SerializerTestDummy Dummy { get; set; }

        [SetUp]
        public void Setup() {
            Serializer = new Serializer();
            Dummy = new SerializerTestDummy();
        }

        [Test]
        public void TestJsonSerialize() {
            string result;
            using (var stream = new StringMemoryStream()) {
                Serializer.JsonSerialize(stream, Dummy);
                result = stream.ToDecodedString();
            }

            Assert.AreEqual(DummyJson, result);
        }

        [Test]
        public void TestJsonDeserialize() {
            var json = DummyJson;

            SerializerTestDummy result;
            using (var stream = new StringMemoryStream(json)) {
                result = Serializer.JsonDeserialize<SerializerTestDummy>(stream);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(Dummy.James, result.James);
            Assert.AreEqual(Dummy.Scott, result.Scott);
        }

        [Test]
        public void TestJsonPopulate() {
            Serializer.JsonPopulate(DummyJson, Dummy);
            Assert.AreEqual("Howlett", Dummy.James);
            Assert.AreEqual("Summers", Dummy.Scott);
        }

        [Test]
        public void TestFormSerialize() {
            string result;
            using (var stream = new StringMemoryStream()) {
                Serializer.FormSerialize(stream, Dummy);
                result = stream.ToDecodedString();
            }
                
            Assert.AreEqual(DummyUrlEncoded, result);
        }
    }

    class SerializerTestDummy {
        public string James { get; set; }
        public string Scott { get; set; }

        [JsonProperty("Johny")] // NOTE: Not uppercased.
        public string Aliased { get; set; }

        public string With { get; set; }
        public DateTime Created { get; set; }
        public bool Checked { get; set; }
        public object FieldIsNull { get; set; }
        public DummyEnum Enumer { get; set; }
        public NestedKlass Nested { get; set; }

        public enum DummyEnum {
            Once,

            [EnumMember(Value = "not_exactly_twice")]
            Twice
        }

        public class NestedKlass {
            public string Field { get; set; }
        }

        public SerializerTestDummy() {
            James = "Howlett";
            Scott = "Summers";
            With = "SPACES SPACES";
            Created = DateTime.MaxValue;
            Aliased = "Mnemonic";
            Checked = true;
            FieldIsNull = null;
            Enumer = DummyEnum.Twice;
            Nested = new NestedKlass { Field = "inner" };
        }
    }
}

