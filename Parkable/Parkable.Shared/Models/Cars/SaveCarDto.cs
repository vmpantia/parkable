namespace Parkable.Shared.Models.Cars
{
    public class SaveCarDto
    {
        public Guid? OwnerId { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Series { get; set; }
        public string BodyType { get; set; }
        public int YearModel { get; set; }
    }
}
