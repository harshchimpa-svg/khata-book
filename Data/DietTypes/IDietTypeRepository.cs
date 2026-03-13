using Domain;

namespace Data.DiteTypes;

public interface IDietTypeRepository
{
    Task Delete(int id);
    Task<DietType> GetById(int id);
    Task Update(DietType dietType);
    Task<List<DietType>> GetAll();
    Task<DietType> Create(DietType dietType);
}