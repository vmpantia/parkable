using Parkable.Infra.Databases.Contracts.Entities;
using Parkable.Shared.Enums;

namespace Parkable.Infra.Databases.Entities
{
    public class Owner : IEntity
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string? LandlineNumber { get; set; }
        public required string Address { get; set; }
        public required Status Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
