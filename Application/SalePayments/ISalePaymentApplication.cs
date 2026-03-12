using Application.SalePayments.Dto;

namespace Application.SalePayments;

public interface ISalePaymentApplication
{
    Task<string> Create(CreateSalePaymentDto dto);
    Task Delete(int id);
    Task<List<SalePaymentDto>> GetAll();
    Task<SalePaymentDto> GetById(int id);
    Task Update(int Id, CreateSalePaymentDto update);   
}