using Microsoft.AspNetCore.Http;

namespace Application.GymDocuments.Dto;

public class CreateGymDocumentDto
{
    public List<IFormFile> ImageUrl { get; set; }
    public int GymId { get; set; }
}