namespace Parkable.Shared.Models.Cars
{
    public class SaveCarDto
    {
        public required Guid OwnerId { get; set; }
        public required string PlateNumber { get; set; }
        public required string Make { get; set; }
        public required string Series { get; set; }
        public required string BodyType { get; set; }
        public required int YearModel { get; set; }
    }
}
