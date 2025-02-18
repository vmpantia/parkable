using FluentValidation;
using Parkable.Shared.Models.Owners;

namespace Parkable.Shared.Validators
{
    public class SaveOwnerDtoValidator : AbstractValidator<SaveOwnerDto>
    {
        public SaveOwnerDtoValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).NotEmpty();
            RuleFor(o => o.EmailAddress).EmailAddress().NotEmpty();
            RuleFor(o => o.PhoneNumber).MaximumLength(11).NotEmpty();
            RuleFor(o => o.Address).NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SaveOwnerDto>.CreateWithOptions((SaveOwnerDto)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid) return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
