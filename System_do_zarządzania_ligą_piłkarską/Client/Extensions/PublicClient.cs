 namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class PublicClient
    {
        public HttpClient Client { get; }

        public PublicClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
