using FluentValidation;
using Parkable.Core.Owners.Commands;

namespace Parkable.Core.Owners.Validators
{
    public class UpdateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(coc => coc.FirstName).NotEmpty();
            RuleFor(coc => coc.LastName).NotEmpty();
            RuleFor(coc => coc.EmailAddress).EmailAddress().NotEmpty();
            RuleFor(coc => coc.PhoneNumber).MaximumLength(11).NotEmpty();
            RuleFor(coc => coc.Address).NotEmpty();
        }
    }
}