namespace SkiResort.Frontend.Presentation;

public interface IHttpApiClientFactory
{
    Task<SkiResortApiClient.SkiResortApiClient> GetSkiResortApiHttpClientAsync();
}
