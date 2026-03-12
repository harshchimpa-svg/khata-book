using Application.ExerciseDocuments.Dto;
using Application.Exercises.Dto;

namespace Application.ExerciseDocuments;

public interface IExerciseDocumentApplication
{
    Task<string> Create(CreateExerciseDocumentDto dto);
    Task Delete(int id);
    Task<List<ExerciseDocumentDto>> GetAll();
    Task<ExerciseDocumentDto> GetById(int id);
    Task Update(int Id, CreateExerciseDocumentDto update);
}