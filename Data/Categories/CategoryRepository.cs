
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
        var category = await _context.Categorys.FindAsync(id);
        _context.Categorys.Remove(category);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Category>> GetAll()
    {
        var category = await _context.Categorys.ToListAsync();
        return category;
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categorys.FindAsync(id);
    }
    public async Task<Category> Create(Category category)
    {
        await _context.Categorys.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task Update(Category category)
    {
        _context.Categorys.Update(category);
        await _context.SaveChangesAsync();
    }
}