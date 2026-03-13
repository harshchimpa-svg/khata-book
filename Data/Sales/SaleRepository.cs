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
        var saleRepository = await _context.Sales.FindAsync(id);
        _context.Sales.Remove(saleRepository);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Sale>> GetAll()
    {
        var saleRepository = await _context.Sales.ToListAsync();
        return saleRepository;
    }

    public async Task<Sale> GetById(int id)
    {
        return await _context.Sales.FindAsync(id);
    }
    public async Task<Sale> Create(Sale saleRepository)
    {
        await _context.Sales.AddAsync(saleRepository);
        await _context.SaveChangesAsync();

        return saleRepository;
    }

    public async Task Update(Sale saleRepository)
    {
        _context.Sales.Update(saleRepository);
        await _context.SaveChangesAsync();
    }
}