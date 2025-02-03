using Microsoft.EntityFrameworkCore;
using Parkable.Infra.Databases.Contexts;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ParkableDbContext context) : base(context) { }

        public async Task<IEnumerable<Car>> GetCardsAsync(CancellationToken cancellationToken)
        {
            var result = await GetAll()
                .Include(tbl => tbl.Owner)
                .AsSplitQuery()
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
