using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Tests.Util;

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
            var authHeader = DummyCredentials.SecretKey.EncodeForAuthorizationHeader();
            var roundtripper = new MockRoundtripper((req) => Assert.AreEqual(authHeader, req.Headers["Authorization"]));
            var requester = BuildRequester(roundtripper);
                
            await requester.Request<object>(Endpoint.Api, "GET", "/test");
            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public async void TestRequestWithPayload() {
            var payload = new DummyPayload { Hello = "World" };
            var payloadJson = "{\"Hello\":\"World\"}";

            var roundtripper = new MockRoundtripper((request) => {
                    var mockRequest = (MockWebRequest)request;
                    var bytes = mockRequest.RequestStream.ToArray();
                    Assert.AreEqual(payloadJson, Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                });
            var requester = BuildRequester(roundtripper);

            await requester.Request<object, DummyPayload>(Endpoint.Api, "POST", "/test", payload);
            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public void TestRequestWithErrorResponse() {
            var roundtripper = new MockRoundtripper(responseInspector: (response) => {
                    throw new WebException("Mock error", null, WebExceptionStatus.Success, response);
                });
            var requester = BuildRequester(roundtripper);

            var task = requester.Request<object>(Endpoint.Api, "GET", "/test");
            Assert.Throws<AggregateException>(task.Wait);
            Assert.AreEqual(1, roundtripper.RoundtripCount);
            Assert.IsNotNull(task.Exception);

            var exception = task.Exception.Flatten().InnerException;
            Assert.IsInstanceOf<OmiseException>(exception);
        }

        IRequester BuildRequester(IRoundtripper roundtripper) {
            var requester = new Requester(DummyCredentials);
            requester.Roundtripper = roundtripper;
            return requester;
        }

        class DummyPayload {
            public string Hello { get; set; }
        }
    }
}