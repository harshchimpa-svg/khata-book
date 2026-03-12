using Microsoft.AspNetCore.Http;

namespace Application.ProductDocuments.Dto;

public class CreateProductDocumentDto
{
    public List<IFormFile> ImageUrl { get; set; }
    public int? GymProductId { get; set; }
}