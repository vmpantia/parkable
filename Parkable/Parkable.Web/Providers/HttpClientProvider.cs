using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;
using Parkable.Web.Providers.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace Parkable.Web.Providers
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly ILogger<HttpClientProvider> _logger;

        public HttpClientProvider(HttpClient httpClient,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager, 
            ILogger<HttpClientProvider> logger)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
            _logger = logger;
        }

        public async Task<TData> GetAsync<TData>(string uri) where TData : class =>
            await SendRequestAsync<TData>(HttpMethod.Get, uri);

        public async Task<TData> PostAsync<TData>(string uri, object data) where TData : class =>
            await SendRequestAsync<TData>(HttpMethod.Post, uri, data);

        public async Task<TData> PutAsync<TData>(string uri, object data) where TData : class =>
            await SendRequestAsync<TData>(HttpMethod.Put, uri, data);

        private async Task SetAuthorizeHeaderAsync()
        {
            // Get auth token if any
            var token = await _localStorageService.GetItemAsync<string>("authToken");

            // Add bearer token as a default request header
            if (token != null && !string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private async Task<TData> SendRequestAsync<TData>(HttpMethod method, string uri, object? data = null)
            where TData : class
        {
            try
            {
                // Set bearer token if any
                await SetAuthorizeHeaderAsync();

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

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string content = await response.Content.ReadAsStringAsync();

                    // Convert the content to result object
                    var result = JsonConvert.DeserializeObject<Result<TData, Error>>(content);

                    // Check the result of the request
                    if (result is not null && result.IsSuccess && response.IsSuccessStatusCode)
                        return result.Data!;

                    throw new Exception(result?.Error?.Message ?? content);
                }
                else if (response.StatusCode is HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException($"User is not authorized to send a request on api {method.ToString()}: {uri}.");
                else 
                    return default;
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex.Message);

                // Force logout user when it's not authorized to send request on APIs
                _navigationManager.NavigateTo("/logout");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: {method.ToString()} | Uri: {uri} | Error Message: {ex.Message}");
                throw;
            }
        }
    }
}
