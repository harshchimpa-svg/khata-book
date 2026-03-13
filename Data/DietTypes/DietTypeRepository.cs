using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.DiteTypes;

public class DietTypeRepository:IDietTypeRepository
{
    private readonly DataContext _context;

    public DietTypeRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var ditetype = await _context.Dites.FindAsync(id);
        _context.Dites.Remove(ditetype);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<DietType>> GetAll()
    {
        var ditetype = await _context.DiteTypes.ToListAsync();
        return ditetype;
    }

    public async Task<DietType> GetById(int id)
    {
        return await _context.DiteTypes.FindAsync(id);
    }
    public async Task<DietType> Create(DietType ditetype)
    {
        await _context.DiteTypes.AddAsync(ditetype);
        await _context.SaveChangesAsync();

        return ditetype;
    }

    public async Task Update(DietType ditetype)
    {
        _context.DiteTypes.Update(ditetype);
        await _context.SaveChangesAsync();
    }
}