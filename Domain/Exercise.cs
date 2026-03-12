using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Exercise
{
    public int Id { get; set; }
    
    [ForeignKey("DietType")]
    public int? DietTypeId { get; set; }
    public DietType? DietType { get; set; }
    
    public string Name { get; set; }
    public string? Description { get; set; }
}