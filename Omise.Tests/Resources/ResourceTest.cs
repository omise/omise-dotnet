using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Omise.Models;
using Omise.Tests.Util;

namespace Omise.Tests.Resources
{
    public abstract class ResourceTest<TResource> : OmiseTest
    {
        protected MockRequester Requester { get; private set; }
        protected IEnvironment Environment { get; private set; }
        protected TResource Resource { get; private set; }
        protected Serializer Serializer { get; private set; }

        protected TResource Fixtures { get; private set; }

        [SetUp]
        public void Setup()
        {
            Requester = new MockRequester();
            Resource = BuildResource(Requester);
            Serializer = new Serializer();
            Environment = Environments.Production;

            var fixtures = new Requester(
                DummyCredentials,
                Environments.Production,
                new FixturesRoundtripper()
            );
            Fixtures = BuildResource(fixtures);
        }

        protected abstract TResource BuildResource(IRequester requester);

        protected void AssertRequest(
            string method,
            string uriFormat,
            params object[] uriArgs
        )
        {
            var attempt = Requester.LastRequest;

            var uri = string.Format(uriFormat, uriArgs);
            var expectedUri = Environment.ResolveEndpoint(attempt.Endpoint) + attempt.Path;

            Assert.AreEqual(method, attempt.Method);
            Assert.AreEqual(uri, expectedUri);
        }

        protected void AssertSerializedRequest<TRequest>(
            TRequest request,
            string serialized
        ) where TRequest : Params
        {
            using (var ms = new StringMemoryStream())
            {
                Serializer.JsonSerialize(ms, request);
                Assert.AreEqual(serialized, ms.ToDecodedString());
            }
        }

        protected void AssertSerializedRequest<TRequest>(
            TRequest request,
            IDictionary<string, object> expected
        ) where TRequest : Params
        {
            expected = Sort(expected);

            var actual = Serialize(request);
            var expectedValue = Serialize(expected);

            Assert.AreEqual(expectedValue, actual);
        }

        string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                Converters = new JsonConverter[]
                {
                    new EnumValueConverter()
                },
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomContractResolver()
            });
        }

        SortedDictionary<string, object> Sort(IDictionary<string, object> dict)
        {
            var values = new SortedDictionary<string, object>();

            foreach(var kv in dict)
            {
                if (kv.Value is IDictionary<string, object>)
                {
                    values.Add(kv.Key, Sort(kv.Value as IDictionary<string, object>));
                }
                else
                {
                    values.Add(kv.Key, kv.Value);
                }
            }

            return values;
        }
    }

    public class CustomContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).OrderBy(x => x.PropertyName).ToList();
        }
    }
}