using Parkable.Infra.Databases.Entities;

namespace Parkable.Core.Users.Inferfaces
{
    public interface ITokenProvider
    {
        string Create(User user);
    }
}