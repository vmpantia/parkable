using Newtonsoft.Json;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;
using Parkable.Web.Providers.Interfaces;
using System.Net.Http.Headers;

namespace Parkable.Web.Providers
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientProvider> _logger;

        public HttpClientProvider(HttpClient httpClient, ILogger<HttpClientProvider> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<TData> GetAsync<TData>(string uri) where TData : class =>
            await SendRequestAsync<TData>(HttpMethod.Get, uri);

        public async Task<TData> PostAsync<TData>(string uri, object data) where TData : class =>
            await SendRequestAsync<TData>(HttpMethod.Post, uri, data);

        private async Task<TData> SendRequestAsync<TData>(HttpMethod method, string uri, object? data = null)
            where TData : class
        {
            // Create the HTTP request message
            var request = new HttpRequestMessage(method, uri);

            // Prepare content if the data is not null
            if (data is not null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(data),
                    System.Text.Encoding.UTF8,
                    "application/json");
            }

            // Add headers to the request if necessary
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Send the request and get the response
            var response = await _httpClient.SendAsync(request);

            // Read the response content
            string content = await response.Content.ReadAsStringAsync();

            // Convert the content to result object
            var result = JsonConvert.DeserializeObject<Result<TData, Error>>(content);

            // Check the result of the request
            if (result is not null && result.IsSuccess && response.IsSuccessStatusCode)
                return result.Data!;

            throw new Exception(result?.Error?.Message ?? content);
        }
    }
}
