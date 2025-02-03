using Microsoft.EntityFrameworkCore;
using Parkable.Infra.Databases.Contexts;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ParkableDbContext context) : base(context) { }

        public async Task<IEnumerable<Owner>> GetOwnersAsync(CancellationToken cancellationToken)
        {
            var result = await GetAll()
                .Include(tbl => tbl.Cars)
                .AsSplitQuery()
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Owner?> GetOwnerByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await GetByExpression(own => own.Id == id)
                .Include(tbl => tbl.Cars)
                .AsSplitQuery()
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
