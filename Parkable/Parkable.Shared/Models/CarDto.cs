using Parkable.Shared.Enums;

namespace Parkable.Shared.Models
{
    public class CarDto
    {
        public required Guid Id { get; set; }
        public required string PlateNumber { get; set; }
        public required string Make { get; set; }
        public required string Series { get; set; }
        public required string BodyType { get; set; }
        public required int YearModel { get; set; }
        public required Status Status { get; set; }
        public required DateTime LastUpdateAt { get; set; }
        public required string LastUpdateBy { get; set; }
    }
}
