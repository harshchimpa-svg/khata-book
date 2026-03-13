using Application.Categories.Dto;

namespace Application.Categories;

public interface ICategoryApplication
{
    Task<string> Create(CreateCategoryDto dto);
    Task Delete(int id);
    Task<List<CategoryDto>> GetAll();
    Task<CategoryDto> GetById(int id);
    Task Update(int id, CreateCategoryDto update);
}