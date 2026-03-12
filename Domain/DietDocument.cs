using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class DietDocument
{
    public int Id { get; set; }
    [ForeignKey("Diet")]
    public int? DietId { get; set; }
    public Diet Diet { get; set; }
    public string Document { get; set; }
}