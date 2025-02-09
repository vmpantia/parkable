using Microsoft.AspNetCore.Components.Authorization;
using Parkable.Web.Providers;
using Parkable.Web.Providers.Interfaces;
using Parkable.Web.Services;
using Parkable.Web.Services.Interfaces;

namespace Parkable.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientProvider, HttpClientProvider>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IOwnerService, OwnerService>();
        }
    }
}
