using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class CartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("GymProduct")]
    public int? GymProductId { get; set; }
    // public GymProduct GymProduct { get; set; }
}