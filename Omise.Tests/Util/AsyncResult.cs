using System;
using System.Threading;

namespace Omise.Tests.Util
{
    public class AsyncResult<TResult> : IAsyncResult where TResult : class
    {
        public object AsyncState { get { return null; } }
        public WaitHandle AsyncWaitHandle { get; private set; }

        public bool CompletedSynchronously { get { return false; } }
        public bool IsCompleted { get { return true; } }

        public TResult Result { get; private set; }

        public AsyncResult(TResult result)
        {
            Result = result;
            AsyncWaitHandle = new ManualResetEvent(true);
        }
    }
}

