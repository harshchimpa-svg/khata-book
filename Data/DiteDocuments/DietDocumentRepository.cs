using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.DiteDocuments;

public class DietDocumentRepository:IDietDocumentRepository
{
    private readonly DataContext _context;

    public DietDocumentRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.DietDocuments.FindAsync(id);
        _context.DietDocuments.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<DietDocument>> GetAll()
    {
        var about = await _context.DietDocuments.ToListAsync();
        return about;
    }

    public async Task<DietDocument> GetById(int id)
    {
        return await _context.DietDocuments.FindAsync(id);
    }
    public async Task<DietDocument> Create(DietDocument about)
    {
        await _context.DietDocuments.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(DietDocument about)
    {
        _context.DietDocuments.Update(about);
        await _context.SaveChangesAsync();
    }
}