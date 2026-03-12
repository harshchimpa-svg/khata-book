using Domain.Enums;

namespace Application.SalePayments.Dto;

public class SalePaymentDto
{
    public int Id { get; set; }
    public int? SaleId { get; set; }
    public MethodType MethodType { get; set; }
    public decimal NetAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    public StatusType StatusType  { get; set; }
}