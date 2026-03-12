using Domain;

namespace Data.GymProducts;

public interface IGymProductRepository
{
    Task Delete(int id);
    Task<GymProduct> GetById(int id);
    Task Update(GymProduct gymDocument);
    Task<List<GymProduct>> GetAll();
    Task<GymProduct> Create(GymProduct gymDocument);    
}