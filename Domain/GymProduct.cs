using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class GymProduct
{
    public int Id { get; set; }
    public int Tax {  get; set; }
    public decimal Price { get; set; }

    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public Category GymCategory{ get; set; }
}