using Application.Sales.Dto;

namespace Application.Sales;

public interface ISaleApplication
{
    Task<string> Create(CreateSaleDto dto);
    Task Delete(int id);
    Task<List<SaleDto>> GetAll();
    Task<SaleDto> GetById(int id);
    Task Update(int Id, CreateSaleDto update);
}