using Parkable.Infra.Databases.Contracts.Entities;
using Parkable.Shared.Enums;

namespace Parkable.Infra.Databases.Entities
{
    public class Car : IEntity
    {
        public required Guid Id { get; set; }
        public required Guid OwnerId { get; set; }
        public required string PlateNumber { get; set; }
        public required string Make { get; set; }
        public required string Series { get; set; }
        public required string BodyType { get; set; }
        public required int YearModel { get; set; }
        public required Status Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
