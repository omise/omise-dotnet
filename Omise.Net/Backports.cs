namespace Omise.Net
{
    // System.Func type is unavailable pre-net35
    internal delegate TResult OFunc<T1, TResult>(T1 arg1);
}

