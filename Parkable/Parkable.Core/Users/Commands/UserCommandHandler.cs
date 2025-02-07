using MediatR;
using Parkable.Core.Users.Inferfaces;
using Parkable.Infra.Databases.Contracts.Repositories;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Users.Commands
{
    public class UserCommandHandler : IRequestHandler<LoginCommand, Result<string, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IPasswordHasher _passwordHasher;

        public UserCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<string, Error>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Get user using username and email address in the database
            var user = await _userRepository.GetUserByUsernameOrEmailAsync(request.UsernameOrEmailAddress, cancellationToken);

            // Check if user exist on the database
            if (user is null) return UserError.UsernameOrEmailAddressNotFound();

            // Check if the user password matched on the given password
            if (!_passwordHasher.Verify(request.Password, user.Password)) return UserError.PasswordIncorrect();

            // Generate user access token using jwt
            var token = _tokenProvider.Create(user);

            return token;
        }
    }
}
