using Microsoft.AspNetCore.Http;

namespace Application.Categories.Dto;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public IFormFile ImageUrl { get; set; }
    public string Description { get; set; }
    public int? ParentId { get; set; }
}