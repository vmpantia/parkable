using Parkable.Shared.Models;

namespace Parkable.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto login);
    }
}