using Application.DietDocuments.Dto;

namespace Application.DietDocuments;

public interface IDietDocumentApplication
{
    Task<string> Create(CreateDietDocumentDto dto);
    Task Delete(int id);
    Task<List<DietDocumentDto>> GetAll();
    Task<DietDocumentDto> GetById(int id);
    Task Update(int Id, CreateDietDocumentDto update);
}