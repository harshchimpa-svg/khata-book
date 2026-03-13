namespace Application.Sales.Dto;

public class CreateSaleDto
{
    public Guid? UserId { get; set; }
    public bool IsPaid { get; set; }
    public bool IsCanceld { get; set; }
    public string? InvoiceNo { get; set; }
    public decimal Discount { get; set; }
    public decimal NetAmount { get; set; }
    public int? Tax  { get; set; }
}