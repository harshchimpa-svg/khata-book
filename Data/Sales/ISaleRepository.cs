using Domain;

namespace Data.Sales;

public interface ISaleRepository
{
    Task Delete(int id);
    Task<Sale> GetById(int id);
    Task Update(Sale sale);
    Task<List<Sale>> GetAll();
    Task<Sale> Create(Sale sale);   
}