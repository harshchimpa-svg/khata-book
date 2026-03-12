using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Gym
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }

    [ForeignKey("Location")]
    public int? LocationId { get; set; }
    public Location Location { get; set; }
}