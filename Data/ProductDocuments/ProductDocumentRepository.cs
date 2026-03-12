using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.ProductDocuments;

public class ProductDocumentRepository:IProductDocumentRepository
{
    private readonly DataContext _context;

    public ProductDocumentRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.ProductDocuments.FindAsync(id);
        _context.ProductDocuments.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<ProductDocument>> GetAll()
    {
        var about = await _context.ProductDocuments.ToListAsync();
        return about;
    }

    public async Task<ProductDocument> GetById(int id)
    {
        return await _context.ProductDocuments.FindAsync(id);
    }
    public async Task<ProductDocument> Create(ProductDocument about)
    {
        await _context.ProductDocuments.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(ProductDocument about)
    {
        _context.ProductDocuments.Update(about);
        await _context.SaveChangesAsync();
    }
}