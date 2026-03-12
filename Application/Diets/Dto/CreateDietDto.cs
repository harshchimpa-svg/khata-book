namespace Application.Dites.Dto;

public class CreateDietDto
{
    public int? DietTypeId { get; set; }
    public   string Name { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
}