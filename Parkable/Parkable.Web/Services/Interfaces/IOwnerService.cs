using Parkable.Shared.Models.Owners;

namespace Parkable.Web.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetOwnersAsync();
        Task<OwnerDto> GetOwnerByIdAsync(Guid id);
        Task<string> SaveOwnerAsync(SaveOwnerDto dto);
        Task<string> SaveOwnerAsync(Guid id, SaveOwnerDto dto);
    }
}