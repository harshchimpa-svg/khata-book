using Domain;

namespace Data.SaleProducts;

public interface ISaleProductRepository
{
    Task Delete(int id);
    Task<SaleProduct> GetById(int id);
    Task Update(SaleProduct productDocument);
    Task<List<SaleProduct>> GetAll();
    Task<SaleProduct> Create(SaleProduct productDocument); 
}