using Parkable.Infra.Databases.Contracts.Entities;
using Parkable.Shared.Enums;

namespace Parkable.Infra.Databases.Entities
{
    public class User : IEntity
    {
        public required Guid Id { get; set; }
        public required string EmailAddress { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required UserType Type { get; set; }
        public required Status Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
