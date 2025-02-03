using Microsoft.EntityFrameworkCore;
using Parkable.Infra.Databases.Contexts;
using Parkable.Infra.Databases.Contracts.Entities;
using Parkable.Infra.Databases.Contracts.Repositories;
using System.Linq.Expressions;

namespace Parkable.Infra.Databases.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _table;
        private readonly ParkableDbContext _context;

        public BaseRepository(ParkableDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            var result = _table.AsNoTracking();
            return result;
        }

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            var result = _table.Where(expression).AsNoTracking();
            return result;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _table.FindAsync(id, cancellationToken);
            return result;
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _table.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
