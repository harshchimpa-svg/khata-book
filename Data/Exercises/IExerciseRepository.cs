using Domain;

namespace Data.Exercises;

public interface IExerciseRepository
{
    Task Delete(int id);
    Task<Exercise> GetById(int id);
    Task Update(Exercise exercise);
    Task<List<Exercise>> GetAll();
    Task<Exercise> Create(Exercise exercise);
}