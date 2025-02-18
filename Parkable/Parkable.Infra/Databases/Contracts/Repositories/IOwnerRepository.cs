using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Contracts.Repositories
{
    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        Task<IEnumerable<Owner>> GetOwnersAsync(CancellationToken cancellationToken);
        Task<Owner?> GetOwnerByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}