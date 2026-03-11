using Domain;

namespace Data.Categories;

public interface ICategoryRepository
{
    Task Delete(int id);
    Task<Category> GetById(int id);
    Task Update(Category category);
    Task<List<Category>> GetAll();
    Task<Category> Create(Category category);
}