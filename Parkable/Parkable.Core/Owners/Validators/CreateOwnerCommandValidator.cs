using FluentValidation;
using Parkable.Core.Owners.Commands;

namespace Parkable.Core.Owners.Validators
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).NotEmpty();
            RuleFor(o => o.EmailAddress).EmailAddress().NotEmpty();
            RuleFor(o => o.PhoneNumber).MaximumLength(11).NotEmpty();
            RuleFor(o => o.Address).NotEmpty();
        }
    }
}
