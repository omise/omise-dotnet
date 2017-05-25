using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Omise.Tests.Util;

namespace Omise.Tests
{
    [TestFixture]
    public class SerializerTest : OmiseTest
    {
        const string DummyJson =
            @"{""james"":""Howlett"",""scott"":""Summers"",""johny"":""Mnemonic""," +
            @"""with"":""SPACES SPACES"",""created"":""9999-12-31T23:59:59.9999999""," +
            @"""checked"":true,""enumer"":""twth"",""enumer2"":""once"",""nullEnum"":null," +
            @"""nested"":{""field"":""inner""," +
            @"""filters"":{""dictionary"":""should works""}}}";
        const string DummyUrlEncoded =
            "james=Howlett&scott=Summers&Johny=Mnemonic&" +
            "with=SPACES+SPACES&created=9999-12-31T23%3A59%3A59Z&" +
            "checked=true&enumer=twth&enumer2=once&" +
            "nested%5Bfield%5D=inner&nested%5Bfilters%5D%5Bdictionary%5D=should+works";

        Serializer Serializer { get; set; }
        SerializerTestDummy Dummy { get; set; }

        [SetUp]
        public void Setup()
        {
            Serializer = new Serializer();
            Dummy = new SerializerTestDummy();
        }

        [Test]
        public void TestJsonSerialize()
        {
            string result;
            using (var stream = new StringMemoryStream())
            {
                Serializer.JsonSerialize(stream, Dummy);
                result = stream.ToDecodedString();
            }

            Assert.AreEqual(DummyJson, result);
        }

        [Test]
        public void TestJsonDeserialize()
        {
            var json = DummyJson;

            SerializerTestDummy result;
            using (var stream = new StringMemoryStream(json))
            {
                result = Serializer.JsonDeserialize<SerializerTestDummy>(stream);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(Dummy.James, result.James);
            Assert.AreEqual(Dummy.Scott, result.Scott);
        }

        [Test]
        public void TestJsonPopulate()
        {
            Serializer.JsonPopulate(DummyJson, Dummy);
            Assert.AreEqual("Howlett", Dummy.James);
            Assert.AreEqual("Summers", Dummy.Scott);
        }

        [Test]
        public async Task TestExtractFormValues()
        {
            var content = Serializer.ExtractFormValues(Dummy);
            var result = await content.ReadAsStringAsync();
            Assert.AreEqual(DummyUrlEncoded, result);
        }
    }

    class SerializerTestDummy
    {
        public string James { get; set; }
        public string Scott { get; set; }

        [JsonProperty("Johny")] // NOTE: Not uppercased.
        public string Aliased { get; set; }

        public string With { get; set; }
        public DateTime Created { get; set; }
        public bool Checked { get; set; }
        public object FieldIsNull { get; set; }
        public DummyEnum Enumer { get; set; }
        public DummyEnum Enumer2 { get; set; }
        public DummyEnum NullEnum { get; set; }
        public NestedKlass Nested { get; set; }

        public enum DummyEnum
        {
            [EnumMember(Value = null)]
            None,
            Once,
            [EnumMember(Value = "twth")]
            TwiceThrice,
        }

        public class NestedKlass
        {
            public string Field { get; set; }
            public IDictionary<string, string> Filters { get; set; }
        }

        public SerializerTestDummy()
        {
            James = "Howlett";
            Scott = "Summers";
            With = "SPACES SPACES";
            Created = DateTime.MaxValue;
            Aliased = "Mnemonic";
            Checked = true;
            FieldIsNull = null;
            Enumer = DummyEnum.TwiceThrice;
            Enumer2 = DummyEnum.Once;
            NullEnum = DummyEnum.None;
            Nested = new NestedKlass
            {
                Field = "inner",
                Filters = new Dictionary<string, string> {
                    { "dictionary", "should works" }
                }
            };
        }
    }
}

