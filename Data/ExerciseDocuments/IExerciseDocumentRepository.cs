using Domain;

namespace Data.ExerciseDocuments;

public interface IExerciseDocumentRepository
{
    Task Delete(int id);
    Task<ExerciseDocument> GetById(int id);
    Task Update(ExerciseDocument exercisedocument);
    Task<List<ExerciseDocument>> GetAll();
    Task<ExerciseDocument> Create(ExerciseDocument exercisedocument);
}