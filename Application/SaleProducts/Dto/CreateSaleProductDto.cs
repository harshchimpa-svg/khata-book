namespace Application.SaleProducts.Dto;

public class CreateSaleProductDto
{
    public int? SaleId { get; set; }
    public int? ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
}