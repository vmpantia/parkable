using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Contracts.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetOwnersAsync(CancellationToken cancellationToken);
    }
}