using Domain;

namespace Data.DiteDocuments;

public interface IDietDocumentRepository
{
    Task Delete(int id);
    Task<DietDocument> GetById(int id);
    Task Update(DietDocument diet);
    Task<List<DietDocument>> GetAll();
    Task<DietDocument> Create(DietDocument diet);
}