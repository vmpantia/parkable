using Parkable.Shared.Models;

namespace Parkable.Web.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto login);
    }
}