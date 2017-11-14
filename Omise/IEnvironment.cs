namespace Omise
{
    public interface IEnvironment
    {
        string ResolveEndpoint(Endpoint endpoint);
        Key SelectKey(Endpoint endpoint, Credentials credentials);
    }
}
