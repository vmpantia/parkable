using Parkable.Shared.Models.Owners;
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

        public async Task<IEnumerable<OwnerDto>> GetOwnersAsync() =>
            await _httpClientProvider.GetAsync<IEnumerable<OwnerDto>>("https://localhost:7103/api/Owners");

        public async Task<OwnerDto> GetOwnerByIdAsync(Guid id) =>
            await _httpClientProvider.GetAsync<OwnerDto>($"https://localhost:7103/api/Owners/{id}");

        public async Task<string> SaveOwnerAsync(SaveOwnerDto dto) =>
            await _httpClientProvider.PostAsync<string>($"https://localhost:7103/api/Owners", dto);
    }
}
