using Application.Categories.Dto;
using AutoMapper;
using Data.Categories;
using Data.Services;
using Domain;

namespace Application.Categories;

public class CategoryApplication : ICategoryApplication
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CategoryApplication(ICategoryRepository categoryRepository, IFileService fileService, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<string> Create(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        if (dto.ImageUrl != null)
        {
            category.ImageUrl = await _fileService.UploadImage(dto.ImageUrl, "categories");
        }

        await _categoryRepository.Create(category);

        return "Category Created";
    }

    public async Task Update(int id, CreateCategoryDto dto)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null)
            throw new Exception("Category not found");

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

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null)
            return null;

        return _mapper.Map<CategoryDto>(category);
    }
}