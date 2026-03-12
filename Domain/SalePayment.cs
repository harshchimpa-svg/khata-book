using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain;

public class SalePayment
{
    public int Id { get; set; }
    [ForeignKey("Sale")]
    public int? SaleId { get; set; }
    public Sale Sale { get; set; }
    
    public MethodType MethodType { get; set; }
    public decimal NetAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    public StatusType StatusType  { get; set; }
}