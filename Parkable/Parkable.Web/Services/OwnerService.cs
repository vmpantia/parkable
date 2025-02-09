using Parkable.Shared.Models;
using Parkable.Web.Providers.Interfaces;
using Parkable.Web.Services.Interfaces;

namespace Parkable.Web.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IHttpClientProvider _httpClientProvider;

        public OwnerService(IHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public async Task<IEnumerable<OwnerDto>> GetOwnersAsync()
        {
            var cars = await _httpClientProvider.GetAsync<IEnumerable<OwnerDto>>("https://localhost:7103/api/Owners");
            return cars;
        }
    }
}
