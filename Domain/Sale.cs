using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Sale
{
    public int Id { get; set; }
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    public User User { get; set; }
    
    public bool IsPaid { get; set; }
    public bool IsCanceld { get; set; }
    public string? InvoiceNo { get; set; }
    public decimal Discount { get; set; }
    public decimal NetAmount { get; set; }
    public int? Tax  { get; set; }
}