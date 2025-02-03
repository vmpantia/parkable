using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Parkable.Infra.Databases.Contracts.Entities;

namespace Parkable.Infra.Databases.Interceptors
{
    internal class AuditEntitiesInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuditEntitiesInterceptor(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            // Get database context on the event data
            var dbContext = eventData.Context;

            // Do nothing when database context is NULL
            if (dbContext is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            // Get all the entries
            var entries = dbContext.ChangeTracker.Entries<IEntity>();

            foreach (var entry in entries)
            {
                // Get requestor info if not exist use default
                var requestor = _httpContextAccessor.HttpContext.User?.Identity?.Name ?? "System";

                if (entry.Entity is IEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = DateTime.UtcNow;
                            entity.CreatedBy = requestor;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedAt = DateTime.UtcNow;
                            entity.ModifiedBy = requestor;
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
