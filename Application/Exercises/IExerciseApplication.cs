using Application.Exercises.Dto;

namespace Application.Exercises;

public interface IExerciseApplication
{
    Task<string> Create(CreateExerciseDto dto);
    Task Delete(int id);
    Task<List<ExerciseDto>> GetAll();
    Task<ExerciseDto> GetById(int id);
    Task Update(int Id, CreateExerciseDto update);
}