using Domain;

namespace Data.Locations;

public interface ILocationRepository
{
    Task Delete(int id);
    Task<Location> GetId(int id);
    Task Update(Location location);
    Task<List<Location>> GetAll();
   Task<Location> Create(Location location);
}
