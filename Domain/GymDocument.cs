using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class GymDocument
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }

    [ForeignKey("Gym")]
    public int GymId { get; set; }
    // public Gym Gym { get; set; }
}