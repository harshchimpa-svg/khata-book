using Application.Transactions.Dto;
using Domain.Enums;

namespace Application.PaymentLogs.Dto;

public class PaymentLogDto
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal TotalDebit { get; set; }
    public List<TransactionDto> Transactions { get; set; }
}