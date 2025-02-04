using System.Net.Http;

namespace CarMarket.Client.Services.HttpService;

public interface IHttpService
{
    Task<T> Get<T>(string url);

    Task<HttpResponseMessage> Post(string url, object data);
}
