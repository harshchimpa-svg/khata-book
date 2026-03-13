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
        var dietdocument = await _context.DietDocuments.FindAsync(id);
        _context.DietDocuments.Remove(dietdocument);
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
    public async Task<DietDocument> Create(DietDocument dietdocument)
    {
        await _context.DietDocuments.AddAsync(dietdocument);
        await _context.SaveChangesAsync();

        return dietdocument;
    }

    public async Task Update(DietDocument dietdocument)
    {
        _context.DietDocuments.Update(dietdocument);
        await _context.SaveChangesAsync();
    }
}