using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Contracts.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCardsAsync(CancellationToken cancellationToken);
    }
}