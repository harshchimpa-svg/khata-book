
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Categories;

public class CategoryRepository:ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var about = await _context.Categorys.FindAsync(id);
        _context.Categorys.Remove(about);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Category>> GetAll()
    {
        var about = await _context.Categorys.ToListAsync();
        return about;
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categorys.FindAsync(id);
    }
    public async Task<Category> Create(Category about)
    {
        await _context.Categorys.AddAsync(about);
        await _context.SaveChangesAsync();

        return about;
    }

    public async Task Update(Category about)
    {
        _context.Categorys.Update(about);
        await _context.SaveChangesAsync();
    }
}