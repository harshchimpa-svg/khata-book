using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Aboutes;

public class AboutRepository:IAboutRepository
{
    private readonly DataContext _context;

    public AboutRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.Abouts.FindAsync(id);
         _context.Abouts.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<About>> GetAll()
    {
        var about = await _context.Abouts.ToListAsync();
        return about;
    }

    public async Task<About> GetById(int id)
    {
        return await _context.Abouts.FindAsync(id);
    }
    public async Task<About> Create(About about)
    {
        await _context.Abouts.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(About about)
    {
        _context.Abouts.Update(about);
        await _context.SaveChangesAsync();
    }
}