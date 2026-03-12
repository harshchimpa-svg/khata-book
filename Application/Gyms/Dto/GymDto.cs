namespace Application.Gyms.Dto;

public class GymDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public int? LocationId { get; set; }
}