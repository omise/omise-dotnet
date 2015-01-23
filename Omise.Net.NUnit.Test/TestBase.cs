using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
    public abstract class TestBase
    {
        protected string secretKey = "123456789";
        protected string publicKey = "123456789";
        protected Omise.Client client;
        protected IRequestManager requestManager;

        [SetUp]
        public virtual void Setup()
        {
            requestManager = MockRepository.GenerateStub<IRequestManager>();
            client = new Omise.Client(requestManager, this.secretKey, this.publicKey);
        }

        [TearDown]
        public virtual void Teardown()
        {
            client = null;
        }

        protected void stubResponse(string response)
        {
            requestManager.Expect(r => r.ExecuteRequest("", "", "")).IgnoreArguments().Return(response).Repeat.Once();
        }

        protected void stubResponse(string path, string method, string response)
        {
            requestManager.Expect(r => r.ExecuteRequest(Arg<string>.Is.Equal(path), Arg<string>.Is.Equal(method), Arg<string>.Is.Anything)).Return(response).Repeat.Once();
        }

        protected void stubResponse(string path, string method, string payload, string response)
        {
            requestManager.Expect(r => r.ExecuteRequest(path, method, payload)).Return(response).Repeat.Once();
        }

        protected void stubException(Exception ex)
        {
            requestManager.Expect(r => r.ExecuteRequest("", "", "")).Throw(ex).IgnoreArguments().Repeat.Once();
        }
    }
}

