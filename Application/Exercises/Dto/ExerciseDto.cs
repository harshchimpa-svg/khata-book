namespace Application.Exercises.Dto;

public class ExerciseDto
{
    public int Id { get; set; }
    public int? DietTypeId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}