using Application.SaleProducts.Dto;

namespace Application.SaleProducts;

public interface ISaleProductApplication
{
    Task<string> Create(CreateSaleProductDto dto);
    Task Delete(int id);
    Task<List<SaleProductDto>> GetAll();
    Task<SaleProductDto> GetById(int id);
    Task Update(int Id, CreateSaleProductDto update);
}