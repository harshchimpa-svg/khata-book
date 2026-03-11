using Domain.Enums;

namespace Application.Transactions.Dto;

public class TransactionDto
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string UserId { get; set; }
}