using Parkable.Shared.Enums;

namespace Parkable.Infra.Databases.Contracts.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Status Status { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModifiedAt { get; set; }
        string? ModifiedBy { get; set; }
    }
}
