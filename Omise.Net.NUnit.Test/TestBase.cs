using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Omise.Net.NUnit.Test
{
	public abstract class TestBase
	{
		protected string apiKey = "123456789";
		protected string apiUrlBase = "http://localhost";
		protected Omise.Client client;
		protected IRequestManager requestManager;

		[SetUp]
		public virtual void Setup(){
			requestManager = MockRepository.GenerateStub<IRequestManager> ();
			client = new Omise.Client (requestManager, this.apiKey, this.apiUrlBase);
		}

		[TearDown]
		public virtual void Teardown(){
			client = null;
		}

		protected void StubRequestWithResponse(string response){
			requestManager.BackToRecord (BackToRecordOptions.All);
			requestManager.Replay ();
			requestManager.Stub (r => r.ExecuteRequest("","","")).Return (response).IgnoreArguments();
		}

		protected void StubExceptionThrow(Exception ex){
			requestManager.BackToRecord (BackToRecordOptions.All);
			requestManager.Replay ();
			requestManager.Stub (r => r.ExecuteRequest("","","")).Throw (ex).IgnoreArguments();
		}
	}
}

