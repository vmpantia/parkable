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
            var owners = await _httpClientProvider.GetAsync<IEnumerable<OwnerDto>>("https://localhost:7103/api/Owners");
            return owners;
        }

        public async Task<OwnerDto> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _httpClientProvider.GetAsync<OwnerDto>($"https://localhost:7103/api/Owners/{id}");
            return owner;
        }
    }
}
