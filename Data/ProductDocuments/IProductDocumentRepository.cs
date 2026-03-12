using Domain;

namespace Data.ProductDocuments;

public interface IProductDocumentRepository
{
    Task Delete(int id);
    Task<ProductDocument> GetById(int id);
    Task Update(ProductDocument productDocument);
    Task<List<ProductDocument>> GetAll();
    Task<ProductDocument> Create(ProductDocument productDocument);   
}