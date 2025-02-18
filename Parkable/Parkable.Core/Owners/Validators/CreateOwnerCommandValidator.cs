using FluentValidation;
using Parkable.Core.Owners.Commands;

namespace Parkable.Core.Owners.Validators
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            RuleFor(coc => coc.FirstName).NotEmpty();
            RuleFor(coc => coc.LastName).NotEmpty();
            RuleFor(coc => coc.EmailAddress).EmailAddress().NotEmpty();
            RuleFor(coc => coc.PhoneNumber).MaximumLength(11).NotEmpty();
            RuleFor(coc => coc.Address).NotEmpty();
        }
    }
}
