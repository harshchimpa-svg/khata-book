using Domain;

namespace Data.GymDocuments;

public interface IGymDocumentRepository
{
    Task Delete(int id);
    Task<GymDocument> GetById(int id);
    Task Update(GymDocument gymDocument);
    Task<List<GymDocument>> GetAll();
    Task<GymDocument> Create(GymDocument gymDocument); 
}