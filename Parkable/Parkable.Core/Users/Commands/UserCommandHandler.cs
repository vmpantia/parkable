using MediatR;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Users.Commands
{
    public class UserCommandHandler : IRequestHandler<LoginCommand, Result<string, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenProvider _tokenProvider;

        public UserCommandHandler(IUserRepository userRepository, TokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
        }

        public async Task<Result<string, Error>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Get user using username and email address in the database
            var user = await _userRepository.GetUserByUsernameOrEmailAsync(request.UsernameOrEmailAddress, cancellationToken);

            // Check if user exist on the database
            if (user is null) return UserError.UsernameOrEmailAddressNotFound();

            // Check if the user password matched on the given password
            if (!user.Password.Equals(request.Password)) return UserError.PasswordIncorrect();

            // Generate user access token using jwt
            var token = _tokenProvider.Create(user);

            return token;
        }
    }
}
