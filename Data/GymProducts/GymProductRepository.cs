using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.GymProducts;

public class GymProductRepository:IGymProductRepository
{
    private readonly DataContext _context;

    public GymProductRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var gymProduct = await _context.GymProducts.FindAsync(id);
        _context.GymProducts.Remove(gymProduct);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<GymProduct>> GetAll()
    {
        var gymProduct = await _context.GymProducts.ToListAsync();
        return gymProduct;
    }

    public async Task<GymProduct> GetById(int id)
    {
        return await _context.GymProducts.FindAsync(id);
    }
    public async Task<GymProduct> Create(GymProduct gymProduct)
    {
        await _context.GymProducts.AddAsync(gymProduct);
        await _context.SaveChangesAsync();

        return gymProduct;
    }

    public async Task Update(GymProduct gymProduct)
    {
        _context.GymProducts.Update(gymProduct);
        await _context.SaveChangesAsync();
    }
}