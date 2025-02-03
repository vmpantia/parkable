using Parkable.Infra.Databases.Contracts.Entities;
using System.Linq.Expressions;

namespace Parkable.Infra.Databases.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}