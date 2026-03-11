using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain;

public class PaymentLog
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    // public User User { get; set; }
    
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [ForeignKey("Transaction")]
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public string? CustomerName { get; set; }
}