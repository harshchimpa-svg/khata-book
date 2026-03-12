using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ProductDocument
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }

    [ForeignKey("Product")]
    public int? GymProductId { get; set; }
    public GymProduct GymProduct { get; set; }
}