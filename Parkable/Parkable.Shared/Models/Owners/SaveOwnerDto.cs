using Parkable.Shared.Models.Cars;

namespace Parkable.Shared.Models.Owners
{
    public class SaveOwnerDto
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? LandlineNumber { get; set; }
        public string Address { get; set; }
        public IEnumerable<SaveCarDto> Cars { get; set; }
    }
}
