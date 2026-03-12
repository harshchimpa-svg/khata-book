using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain;

public class Transaction
{
    public int Id { get; set; }
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string UserId { get; set; }
    public string CreatedBy { get; set; } 
}