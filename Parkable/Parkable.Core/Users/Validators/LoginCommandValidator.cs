using FluentValidation;
using Parkable.Core.Users.Commands;

namespace Parkable.Core.Users.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(o => o.UsernameOrEmailAddress).NotEmpty();
            RuleFor(o => o.Password).NotEmpty();
        }
    }
}
