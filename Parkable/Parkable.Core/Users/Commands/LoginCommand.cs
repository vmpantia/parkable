using MediatR;
using Parkable.Shared.Models;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Users.Commands
{
    public class LoginCommand : IRequest<Result<string, Error>>
    {
        public LoginCommand(LoginDto dto)
        {
            UsernameOrEmailAddress = dto.UsernameOrEmailAddress;
            Password = dto.Password;
        }

        public string UsernameOrEmailAddress { get; init; }
        public string Password { get; init; }
    }
}
