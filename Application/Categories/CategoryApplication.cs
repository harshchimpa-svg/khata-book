using Application.Categories.Dto;
using Data.Categories;
using Data.Services;
using Domain;

namespace Application.Categories;

public class CategoryApplication : ICategoryApplication
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;

    public CategoryApplication(ICategoryRepository aboutRepository, IFileService fileService)
    {
        _categoryRepository = aboutRepository;
        _fileService = fileService;
    }
    public async Task<string> Create(CreateCategoryDto dto)
    {
        string imagePath = null;
        if (dto.ImageUrl != null)
        {
            imagePath = await _fileService.UploadImage(dto.ImageUrl, "categories");
        }

        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = imagePath,
            ParentId = dto.ParentId
        };

        await _categoryRepository.Create(category);
        return "Category Created";
    }

    public async Task Update(int id, CreateCategoryDto dto)
    {
        var category = await _categoryRepository.GetById(id);
        if (category == null) throw new Exception("Category not found");

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.ParentId = dto.ParentId;

        if (dto.ImageUrl != null)
        {
            category.ImageUrl = await _fileService.UploadImage(dto.ImageUrl, "categories");
        }

        await _categoryRepository.Update(category);
    }
    public async Task Delete(int id)
    {
        await _categoryRepository.Delete(id);
    }

    public async Task<List<CategoryDto>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ImageUrl = c.ImageUrl,
            ParentId = c.ParentId
        }).ToList();
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            ParentId = category.ParentId
        };
    }
}