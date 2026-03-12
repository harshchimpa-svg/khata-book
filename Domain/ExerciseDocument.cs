using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ExerciseDocument
{
    public int Id { get; set; }
    
    [ForeignKey("Exercise")]
    public int? ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }
     
    public string Document { get; set; }
}