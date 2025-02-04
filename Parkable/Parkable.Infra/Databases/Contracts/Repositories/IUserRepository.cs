using Parkable.Infra.Databases.Entities;

namespace Parkable.Infra.Databases.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameOrEmailAsync(string userNameOrEmail, CancellationToken cancellationToken);
    }
}