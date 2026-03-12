using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class SaleProduct
{
    public int Id { get; set; }
    
    [ForeignKey("Sale")]
    public int? SaleId { get; set; }
    public Sale Sale { get; set; }
    
    [ForeignKey("Product")]
    public int? ProductId { get; set; }
    public GymProduct  Product { get; set; }
    
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; } 
}