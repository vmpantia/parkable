using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Parkable.Shared.Models;
using Parkable.Web.Providers;
using Parkable.Web.Providers.Interfaces;
using Parkable.Web.Services.Interfaces;

namespace Parkable.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientProvider _httpClientProvider;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IHttpClientProvider httpClientProvider, 
            AuthenticationStateProvider authenticationStateProvider, 
            NavigationManager navigationManager,
            ILogger<AuthenticationService> logger)
        {
            _httpClientProvider = httpClientProvider;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
            _logger = logger;
        }

        public async Task LoginAsync(LoginDto login)
        {
            try
            {
                // Send login request to API
                var token = await _httpClientProvider.PostAsync<string>("https://localhost:7103/api/Auth/Login", login);

                // Check if the token is NOT NULL or Empty
                if (!string.IsNullOrEmpty(token))
                {
                    // Mark user as authenticate using the custom authentication state provider
                    await ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(token);

                    // Redirect user to main page
                    _navigationManager.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in processing login request | Message: {ex.Message}");
            }
        }

        public async Task LogoutAsync()
        {
            // Mark user as logged out using the custom authentication state provider
            await ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();

            // Redirect user to login page
            _navigationManager.NavigateTo("/login");
        }
    }
}
