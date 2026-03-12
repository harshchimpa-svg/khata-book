using Application.GymDocuments.Dto;

namespace Application.GymDocuments;

public interface IGymDocumentApplication
{
    Task<string> Create(CreateGymDocumentDto dto);
    Task Delete(int id);
    Task<List<GymDocumentDto>> GetAll();
    Task<GymDocumentDto> GetById(int id);
    Task Update(int Id, CreateGymDocumentDto update);
}