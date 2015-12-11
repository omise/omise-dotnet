using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using Omise.Tests.Util;
using System.Reflection;
using Omise.Models;
using System.Runtime.Serialization;
using System.Net.Http;

namespace Omise.Tests {
    [TestFixture]
    public class RequesterTest : OmiseTest {
        [Test]
        public void TestCtor() {
            Assert.Throws<ArgumentNullException>(() => new Requester(null));

            var req = new Requester(DummyCredentials);
            Assert.AreEqual(req.Credentials, DummyCredentials);
        }

        [Test, Timeout(1000)]
        public async void TestRequest() {
            var expectedAuthHeader = DummyCredentials.SecretKey.EncodeForAuthorizationHeader();
            var roundtripper = new MockRoundtripper((req) => {
                    var authHeader = req.Headers.GetValues("Authorization").FirstOrDefault();
                    Assert.AreEqual(expectedAuthHeader, authHeader);

                    var libVersion = new AssemblyName(typeof(Requester).Assembly.FullName).Version.ToString();
                    var clrVersion = new AssemblyName(typeof(object).Assembly.FullName).Version.ToString();

                    var userAgents = req.Headers.GetValues("User-Agent").ToList();
                    Assert.Contains("Omise.Net/" + libVersion, userAgents);
                    Assert.Contains(".Net/" + clrVersion, userAgents);
                });
                
            var requester = BuildRequester(roundtripper);
            await requester.Request<object>(Endpoint.Api, "GET", "/test");

            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public async void TestRequestWithResult() {
            var roundtripper = new MockRoundtripper();
            roundtripper.ResponseContent = "{\"id\":\"zxcv\"}";
            roundtripper.ResponseContentType = "application/json";

            var requester = BuildRequester(roundtripper);
            var result = await requester.Request<DummyModel>(Endpoint.Api, "GET", "/test");

            Assert.IsNotNull(result);
            Assert.AreEqual("zxcv", result.Id);
            Assert.AreEqual(requester, result.Requester);
        }
            
        [Test, Timeout(1000)]
        public async void TestRequestWithPayload() {
            var expectedPayload = "hello=Kitty&world=Collides";
            var payload = new DummyPayload
            {
                Hello = "Kitty",
                World = "Collides",
            };

            var roundtripper = new MockRoundtripper(async (request) => {
                    var content = request.Content;
                    var contentType = content.Headers.GetValues("Content-Type").FirstOrDefault();
                    Assert.AreEqual("application/x-www-form-urlencoded", contentType);

                    var encodedPayload = await content.ReadAsStringAsync();
                    Assert.AreEqual(expectedPayload, encodedPayload);
                });

            var requester = BuildRequester(roundtripper);
            await requester.Request<object, DummyPayload>(Endpoint.Api, "POST", "/test", payload);

            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public void TestRequestWithErrorResponse() {
            var roundtripper = new MockRoundtripper(responseInspector: (response) => {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Content = new StringContent("{\"code\":\"test_error\"}");
                });
            var requester = BuildRequester(roundtripper);

            var task = requester.Request<object>(Endpoint.Api, "GET", "/test");
            Assert.Throws<AggregateException>(task.Wait);
            Assert.AreEqual(1, roundtripper.RoundtripCount);
            Assert.IsNotNull(task.Exception);

            var exception = task.Exception.Flatten().InnerException;
            Assert.IsInstanceOf<OmiseError>(exception);
            Assert.IsTrue(exception.ToString().Contains("test_error"));
        }

        IRequester BuildRequester(IRoundtripper roundtripper) {
            return new Requester(DummyCredentials, roundtripper);
        }

        class DummyPayload {
            public string Hello { get; set; }
            public string World { get; set; }
        }

        [DataContract]
        class DummyModel : ModelBase {
        }
    }
}