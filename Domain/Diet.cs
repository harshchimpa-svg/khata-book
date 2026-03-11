using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Diet
{
    public int Id { get; set; }
    
    [ForeignKey("DiteType")]
    public int? DietTypeId { get; set; }
    public DiteType DietType { get; set; }
 
    public   string Name { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
}