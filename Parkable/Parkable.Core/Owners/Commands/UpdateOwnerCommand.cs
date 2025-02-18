using MediatR;
using Parkable.Shared.Models.Owners;
using Parkable.Shared.Results;
using Parkable.Shared.Results.Errors;

namespace Parkable.Core.Owners.Commands
{
    public sealed class UpdateOwnerCommand : IRequest<Result<string, Error>>
    {
        public UpdateOwnerCommand(Guid id, SaveOwnerDto dto) 
        {
            Id = id;
            FirstName = dto.FirstName;
            MiddleName = dto.MiddleName;
            LastName = dto.LastName;
            EmailAddress = dto.EmailAddress;
            PhoneNumber = dto.PhoneNumber;
            LandlineNumber = dto.LandlineNumber;
            Address = dto.Address;
        }

        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
        public string EmailAddress { get; init; }
        public string PhoneNumber { get; init; }
        public string? LandlineNumber { get; init; }
        public string Address { get; init; }
    }
}
