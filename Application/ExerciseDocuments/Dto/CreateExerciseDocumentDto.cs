using Microsoft.AspNetCore.Http;

namespace Application.ExerciseDocuments.Dto;

public class CreateExerciseDocumentDto
{
    public int? ExerciseId { get; set; }
    public List<IFormFile> Document { get; set; }
}