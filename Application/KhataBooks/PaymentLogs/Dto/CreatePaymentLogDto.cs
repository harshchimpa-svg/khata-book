using Application.Transactions.Dto;
using Domain.Enums;

namespace Application.PaymentLogs.Dto;

public class CreatePaymentLogDto
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public int? CustomerId { get; set; }
}