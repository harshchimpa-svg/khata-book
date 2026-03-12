using Domain;

namespace Data.Gyms;

public interface IGymRepository
{
    Task Delete(int id);
    Task<Gym> GetById(int id);
    Task Update(Gym gym);
    Task<List<Gym>> GetAll();
    Task<Gym> Create(Gym gym);     
}