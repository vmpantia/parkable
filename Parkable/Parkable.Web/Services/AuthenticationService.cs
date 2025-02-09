using Parkable.Shared.Models;
using Parkable.Web.Providers.Interfaces;
using Parkable.Web.Services.Interfaces;

namespace Parkable.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientProvider _httpClientProvider;

        public AuthenticationService(IHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public async Task<string> LoginAsync(LoginDto login)
        {
            var token = await _httpClientProvider.PostAsync<string>("https://localhost:7103/api/Auth/Login", login);
            return token;
        }
    }
}
