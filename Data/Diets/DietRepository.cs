using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Dites;

public class DietRepository:IDietRepository
{
    private readonly DataContext _context;

    public DietRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var diet = await _context.Dites.FindAsync(id);
        _context.Dites.Remove(diet);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Diet>> GetAll()
    {
        var diet = await _context.Dites.ToListAsync();
        return diet;
    }

    public async Task<Diet> GetById(int id)
    {
        return await _context.Dites.FindAsync(id);
    }
    public async Task<Diet> Create(Diet diet)
    {
        await _context.Dites.AddAsync(diet);
        await _context.SaveChangesAsync();

        return diet;
    }

    public async Task Update(Diet diet)
    {
        _context.Dites.Update(diet);
        await _context.SaveChangesAsync();
    }
}