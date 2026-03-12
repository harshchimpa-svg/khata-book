using Microsoft.AspNetCore.Http;

namespace Application.Abouts.Dto;

public class CreateAboutDto
{
    public string Name { get; set; }
    public IFormFile Profile { get; set; }
    public string SubTitel { get; set; }
    public string UserId { get; set; } 
}