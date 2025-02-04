using Microsoft.EntityFrameworkCore;
using Parkable.Infra.Databases.Contexts;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ParkableDbContext context) : base(context) { }

        public async Task<User?> GetUserByUsernameOrEmailAsync(string userNameOrEmail, CancellationToken cancellationToken)
        {
            var result = await GetByExpression(u => u.EmailAddress.Equals(userNameOrEmail) || u.Username.Equals(userNameOrEmail))
                .SingleOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
