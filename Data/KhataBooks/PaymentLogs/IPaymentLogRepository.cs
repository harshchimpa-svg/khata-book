using Domain;

namespace Data.PaymentLogs;

public interface IPaymentLogRepository
{
    Task<List<Transaction>> GetAll();
}