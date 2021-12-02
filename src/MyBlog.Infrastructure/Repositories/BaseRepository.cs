using System.Text;

public abstract class BaseRepository
{
    protected readonly IHttpClientFactory Client;
    protected const string MediaType = "application/json";

    protected BaseRepository(IHttpClientFactory client) => Client = client;

    protected StringContent SetRequestContent<TContent>(TContent content) =>
        new(content.ToJson(), Encoding.UTF8, MediaType);
}
