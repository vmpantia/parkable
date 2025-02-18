using MediatR;
using Parkable.Shared.Models.Cars;
using Parkable.Shared.Models.Owners;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Owners.Commands
{
    public sealed class CreateOwnerCommand : IRequest<Result<string, Error>>
    {
        public CreateOwnerCommand(SaveOwnerDto dto)
        {
            FirstName = dto.FirstName;
            MiddleName = dto.MiddleName;
            LastName = dto.LastName;
            EmailAddress = dto.EmailAddress;
            PhoneNumber = dto.PhoneNumber;
            LandlineNumber = dto.LandlineNumber;
            Address = dto.Address;
            Cars = dto.Cars;
        }

        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
        public string EmailAddress { get; init; }
        public string PhoneNumber { get; init; }
        public string? LandlineNumber { get; init; }
        public string Address { get; init; }
        public IEnumerable<SaveCarDto> Cars { get; init; }
    }
}
