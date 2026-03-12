namespace Application.Exercises.Dto;

public class CreateExerciseDto
{
    public int? DietTypeId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}