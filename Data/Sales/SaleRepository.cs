using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Sales;

public class SaleRepository:ISaleRepository
{
    private readonly DataContext _context;

    public SaleRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.Sales.FindAsync(id);
        _context.Sales.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Sale>> GetAll()
    {
        var about = await _context.Sales.ToListAsync();
        return about;
    }

    public async Task<Sale> GetById(int id)
    {
        return await _context.Sales.FindAsync(id);
    }
    public async Task<Sale> Create(Sale about)
    {
        await _context.Sales.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(Sale about)
    {
        _context.Sales.Update(about);
        await _context.SaveChangesAsync();
    }
}