using System;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.ServiceModel.Channels;
using System.ServiceModel;
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
        public void TestRequest() {
            var authHeader = DummyCredentials.SecretKey.EncodeForAuthorizationHeader();
            var requester = new Requester(DummyCredentials);
            var roundtripper = new MockRoundtripper((req) => Assert.AreEqual(authHeader, req.Headers["Authorization"]));
                
            requester.Roundtripper = roundtripper;
            requester.Request<object>(Endpoint.Api, "GET", "/test").Wait();
            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public void TestRequestWithPayload() {
            var payload = new DummyPayload();
            var payloadJson = "{\"Hello\":\"World\"}";

            var requester = new Requester(DummyCredentials);
            var roundtripper = new MockRoundtripper((request) => {
                    var mockRequest = (MockWebRequest)request;
                    var bytes = mockRequest.RequestStream.ToArray();
                    Assert.AreEqual(payloadJson, Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                });

            requester.Roundtripper = roundtripper;
            requester.Request<object, DummyPayload>(Endpoint.Api, "POST", "/test", payload).Wait();
            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }

        [Test, Timeout(1000)]
        public void TestRequestWithErrorResponse() {
            var requester = new Requester(DummyCredentials);
            var roundtripper = new MockRoundtripper(responseInspector: (response) => {
                    throw new WebException("Mock error", null, WebExceptionStatus.Success, response);
                });

            requester.Roundtripper = roundtripper;

            var task = requester.Request<object>(Endpoint.Api, "GET", "/test");
            Assert.Throws<AggregateException>(task.Wait);
            Assert.AreEqual(1, roundtripper.RoundtripCount);
            Assert.IsNotNull(task.Exception);

            var exception = task.Exception.Flatten().InnerException;
            Assert.IsInstanceOf<OmiseException>(exception);
        }

        class DummyPayload {
            public string Hello { get; set; }

            public DummyPayload() {
                Hello = "World";
            }
        }
    }
}