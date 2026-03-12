using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Gyms;

public class GymRepository:IGymRepository
{
    private readonly DataContext _context;

    public GymRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var gym = await _context.Gyms.FindAsync(id);
        _context.Gyms.Remove(gym);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Gym>> GetAll()
    {
        var gym = await _context.Gyms.ToListAsync();
        return gym;
    }

    public async Task<Gym> GetById(int id)
    {
        return await _context.Gyms.FindAsync(id);
    }
    public async Task<Gym> Create(Gym gym)
    {
        await _context.Gyms.AddAsync(gym);
        await _context.SaveChangesAsync();

        return gym;
    }

    public async Task Update(Gym gym)
    {
        _context.Gyms.Update(gym);
        await _context.SaveChangesAsync();
    }
}