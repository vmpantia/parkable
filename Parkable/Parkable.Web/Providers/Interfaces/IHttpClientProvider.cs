namespace Parkable.Web.Providers.Interfaces
{
    public interface IHttpClientProvider
    {
        Task<TData> GetAsync<TData>(string uri) where TData : class;
        Task<TData> PostAsync<TData>(string uri, object data) where TData : class;
    }
}