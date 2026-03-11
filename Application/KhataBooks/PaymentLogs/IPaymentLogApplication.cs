using Application.PaymentLogs.Dto;

namespace Application.PaymentLogs;

public interface IPaymentLogApplication
{
    Task<List<PaymentLogDto>> GetAll();
}