using Domain;

namespace Application.locations.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public LocationType LocationType { get; set; }
    }
}
