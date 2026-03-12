using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Locations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext context)
        {   
            _context = context;
        }
        public async Task Delete(int id)    
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();  
        }
        public async Task<List<Location>> GetAll()
        {
            var location = await _context.Locations.ToListAsync();
            return location;
        }

        public async Task<Location> GetId(int id)
        {
            return await _context.Locations.FindAsync(id);
        }
        public async Task<Location> Create(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return location;
        }

        public async Task Update(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync(); ;
        }
    }
}
