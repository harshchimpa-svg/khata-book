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
        var about = await _context.Dites.FindAsync(id);
        _context.Dites.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Diet>> GetAll()
    {
        var about = await _context.Dites.ToListAsync();
        return about;
    }

    public async Task<Diet> GetById(int id)
    {
        return await _context.Dites.FindAsync(id);
    }
    public async Task<Diet> Create(Diet about)
    {
        await _context.Dites.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(Diet about)
    {
        _context.Dites.Update(about);
        await _context.SaveChangesAsync();
    }
}