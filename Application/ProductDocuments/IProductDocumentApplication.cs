using Application.ProductDocuments.Dto;

namespace Application.ProductDocuments;

public interface IProductDocumentApplication
{
    Task<string> Create(CreateProductDocumentDto dto);
    Task Delete(int id);
    Task<List<ProductDocumentDto>> GetAll();
    Task<ProductDocumentDto> GetById(int id);
    Task Update(int Id, CreateProductDocumentDto update);
}