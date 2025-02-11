using Parkable.Shared.Enums;

namespace Parkable.Shared.Models
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? LandlineNumber { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public DateTime LastUpdateAt { get; set; }
        public string LastUpdateBy { get; set; }
        public IEnumerable<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}
