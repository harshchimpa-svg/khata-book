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
        var productDocument = await _context.ProductDocuments.FindAsync(id);
        _context.ProductDocuments.Remove(productDocument);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<ProductDocument>> GetAll()
    {
        var productDocument = await _context.ProductDocuments.ToListAsync();
        return productDocument;
    }

    public async Task<ProductDocument> GetById(int id)
    {
        return await _context.ProductDocuments.FindAsync(id);
    }
    public async Task<ProductDocument> Create(ProductDocument productDocument)
    {
        await _context.ProductDocuments.AddAsync(productDocument);
        await _context.SaveChangesAsync();

        return productDocument;
    }

    public async Task Update(ProductDocument productDocument)
    {
        _context.ProductDocuments.Update(productDocument);
        await _context.SaveChangesAsync();
    }
}