using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Models;
using Omise.Tests.Util;

namespace Omise.Tests
{
    [TestFixture]
    public class RequesterTest : OmiseTest
    {
        [Test]
        public void TestCtor()
        {
            Assert.That(() => new Requester(null), Throws.ArgumentNullException);

            var req = new Requester(DummyCredentials);
            Assert.That(req.Credentials, Is.EqualTo(DummyCredentials));
        }

        [Test, MaxTime(1000)]
        public async Task TestRequest()
        {
            var expectedAuthHeader = DummyCredentials.SecretKey.EncodeForAuthorizationHeader();
            var roundtripper = new MockRoundtripper((req) =>
            {
                var authHeader = req.Headers.GetValues("Authorization").FirstOrDefault();
                Assert.That(authHeader, Is.EqualTo(expectedAuthHeader));

                var libAsm = typeof(Requester).Assembly;
                var clrAsm = typeof(object).Assembly;

                var libVersion = libAsm.GetName().Version.ToString();
                var clrVersion = clrAsm.GetName().Version.ToString();

                var userAgents = req.Headers.GetValues("User-Agent").ToList();
                Assert.That(userAgents, Contains.Item($"Omise.Net/{libVersion}"));
                Assert.That(userAgents, Contains.Item($".Net/{clrVersion}"));

                var apiVersion = req.Headers.GetValues("Omise-Version").FirstOrDefault();
                Assert.That(apiVersion, Is.EqualTo("2000-02-01"));
            });

            var requester = new Requester(DummyCredentials, roundtripper, "2000-02-01");
            await requester.Request<object>(Endpoint.Api, "GET", "/test");

            Assert.That(roundtripper.RoundtripCount, Is.EqualTo(1));
        }

        [Test, MaxTime(1000)]
        public async Task TestRequestWithResult()
        {
            var roundtripper = new MockRoundtripper();
            roundtripper.ResponseContent = "{\"id\":\"zxcv\"}";
            roundtripper.ResponseContentType = "application/json";

            var requester = BuildRequester(roundtripper);
            var result = await requester.Request<DummyModel>(Endpoint.Api, "GET", "/test");

            Assert.IsNotNull(result);
            Assert.AreEqual("zxcv", result.Id);
            Assert.AreEqual(requester, result.Requester);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("zxcv"));
            Assert.That(result.Requester, Is.EqualTo(requester));
        }

        [Test, MaxTime(1000)]
        public async Task TestRequestWithPayload()
        {
            var expectedPayload = "{\"hello\":\"Kitty\",\"world\":\"Collides\"}";
            var payload = new DummyPayload
            {
                Hello = "Kitty",
                World = "Collides",
            };

            var roundtripper = new MockRoundtripper(async (request) =>
            {
                var content = request.Content;
                var contentType = content.Headers.GetValues("Content-Type").FirstOrDefault();
                Assert.AreEqual(contentType, "application/json; charset=utf-8");

                var task = content.ReadAsStringAsync();
                var encodedPayload = await content.ReadAsStringAsync();
                Assert.AreEqual(expectedPayload, encodedPayload);
            });

            var requester = BuildRequester(roundtripper);
            await requester.Request<object, DummyPayload>(Endpoint.Api, "POST", "/test", payload);

            Assert.That(roundtripper.RoundtripCount, Is.EqualTo(1));
        }

        [Test, MaxTime(1000)]
        public void TestRequestWithErrorResponse()
        {
            var roundtripper = new MockRoundtripper(responseInspector: (response) =>
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("{\"code\":\"test_error\"}");
            });
            var requester = BuildRequester(roundtripper);

            var task = requester.Request<object>(Endpoint.Api, "GET", "/test");
            Assert.That(task.Wait, Throws.InstanceOf<AggregateException>());
            Assert.That(roundtripper.RoundtripCount, Is.EqualTo(1));
            Assert.That(task.Exception, Is.Not.Null);

            var exception = task.Exception.Flatten().InnerException;
            Assert.That(exception, Is.InstanceOf<OmiseError>());
            Assert.That(exception.ToString(), Contains.Substring("test_error"));
        }

        IRequester BuildRequester(IRoundtripper roundtripper)
        {
            return new Requester(DummyCredentials, roundtripper);
        }

        class DummyPayload
        {
            public string Hello { get; set; }
            public string World { get; set; }
        }

        class DummyModel : ModelBase
        {
        }
    }
}