using Domain;

namespace Data.SalePayments;

public interface ISalePaymentRepository
{
    Task Delete(int id);
    Task<SalePayment> GetById(int id);
    Task Update(SalePayment salePayment);
    Task<List<SalePayment>> GetAll();
    Task<SalePayment> Create(SalePayment salePayment);  
}