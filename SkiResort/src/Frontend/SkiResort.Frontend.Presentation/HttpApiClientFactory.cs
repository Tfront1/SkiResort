namespace SkiResort.Frontend.Presentation;

public class HttpApiClientFactory : IHttpApiClientFactory
{
    public async Task<SkiResortApiClient.SkiResortApiClient> GetSkiResortApiHttpClientAsync()
    {
        return new SkiResortApiClient.SkiResortApiClient("https://localhost:7062", new HttpClient());
    }
}
