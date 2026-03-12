using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.SaleProducts;

public class SaleProductRepository:ISaleProductRepository
{
    private readonly DataContext _context;

    public SaleProductRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var saleProduct = await _context.SaleProducts.FindAsync(id);
        _context.SaleProducts.Remove(saleProduct);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<SaleProduct>> GetAll()
    {
        var saleProduct = await _context.SaleProducts.ToListAsync();
        return saleProduct;
    }

    public async Task<SaleProduct> GetById(int id)
    {
        return await _context.SaleProducts.FindAsync(id);
    }
    public async Task<SaleProduct> Create(SaleProduct saleProduct)
    {
        await _context.SaleProducts.AddAsync(saleProduct);
        await _context.SaveChangesAsync();

        return saleProduct;
    }

    public async Task Update(SaleProduct saleProduct)
    {
        _context.SaleProducts.Update(saleProduct);
        await _context.SaveChangesAsync();
    }
}