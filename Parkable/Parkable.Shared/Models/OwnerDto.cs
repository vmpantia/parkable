using Parkable.Shared.Enums;

namespace Parkable.Shared.Models
{
    public class OwnerDto
    {
        public required Guid Id { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string? LandlineNumber { get; set; }
        public required string Address { get; set; }
        public required Status Status { get; set; }
        public required DateTime LastUpdateAt { get; set; }
        public required string LastUpdateBy { get; set; }
        public IEnumerable<CarDto> Cars { get; set; }
    }
}
