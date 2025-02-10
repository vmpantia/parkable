using Parkable.Shared.Models;

namespace Parkable.Web.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task LoginAsync(LoginDto login);
        Task LogoutAsync();
    }
}