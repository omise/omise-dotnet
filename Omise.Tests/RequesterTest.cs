using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Omise.Tests.Util;
using System.Reflection;

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
            var roundtripper = new MockRoundtripper((req) => {
                    Assert.AreEqual(authHeader, req.Headers["Authorization"]);

                    var libVersion = new AssemblyName(typeof(Requester).Assembly.FullName).Version.ToString();
                    var clrVersion = new AssemblyName(typeof(object).Assembly.FullName).Version.ToString();

                    var ua = req.Headers["User-Agent"];
                    Assert.IsNotNull(ua);
                    Assert.IsTrue(ua.Contains("Omise.Net/" + libVersion));
                    Assert.IsTrue(ua.Contains(".Net/" + clrVersion));
                });
                
            var requester = BuildRequester(roundtripper);
            await requester.Request<object>(Endpoint.Api, "GET", "/test");

            Assert.AreEqual(1, roundtripper.RoundtripCount);
        }
            
        [Test, Timeout(1000)]
        public async void TestRequestWithPayload() {
            var encodedPayload = "Hello=Kitty&World=Collides";
            var payload = new DummyPayload
            {
                Hello = "Kitty",
                World = "Collides",
            };

            var roundtripper = new MockRoundtripper((request) => {
                    var mockRequest = (MockWebRequest)request;
                    var bytes = mockRequest.RequestStream.ToArray();

                    Assert.AreEqual("application/x-www-form-urlencoded", mockRequest.Headers["Content-Type"]);
                    Assert.AreEqual(encodedPayload, Encoding.UTF8.GetString(bytes, 0, bytes.Length));
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
            public string World { get; set; }
        }
    }
}