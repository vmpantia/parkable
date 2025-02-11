using Parkable.Shared.Models;

namespace Parkable.Web.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetOwnersAsync();
        Task<OwnerDto> GetOwnerByIdAsync(Guid id);
    }
}