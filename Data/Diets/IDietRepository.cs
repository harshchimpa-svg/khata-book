
using Domain;

namespace Data.Dites;

public interface IDietRepository
{
    Task Delete(int id);
    Task<Diet> GetById(int id);
    Task Update(Diet diet);
    Task<List<Diet>> GetAll();
    Task<Diet> Create(Diet diet);
}