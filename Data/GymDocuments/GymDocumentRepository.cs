using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.GymDocuments;

public class GymDocumentRepository:IGymDocumentRepository
{
    private readonly DataContext _context;

    public GymDocumentRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var gymDocument = await _context.GymDocuments.FindAsync(id);
        _context.GymDocuments.Remove(gymDocument);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<GymDocument>> GetAll()
    {
        var gymDocument = await _context.GymDocuments.ToListAsync();
        return gymDocument;
    }

    public async Task<GymDocument> GetById(int id)
    {
        return await _context.GymDocuments.FindAsync(id);
    }
    public async Task<GymDocument> Create(GymDocument gymDocument)
    {
        await _context.GymDocuments.AddAsync(gymDocument);
        await _context.SaveChangesAsync();

        return gymDocument;
    }

    public async Task Update(GymDocument gymDocument)
    {
        _context.GymDocuments.Update(gymDocument);
        await _context.SaveChangesAsync();
    }
}