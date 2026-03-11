using Domain;
using Domain.Enums;

namespace Application.Transactions.Dto;

public class CreateTransactionDto
{
    public int? CustomerId { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string UserId { get; set; }
    public Customer Customer { get; set; }
} 