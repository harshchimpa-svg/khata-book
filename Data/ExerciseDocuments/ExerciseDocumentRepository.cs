using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.ExerciseDocuments;

public class ExerciseDocumentRepository:IExerciseDocumentRepository
{
    private readonly DataContext _context;

    public ExerciseDocumentRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var exerciseDocument = await _context.ExerciseDocuments.FindAsync(id);
        _context.ExerciseDocuments.Remove(exerciseDocument);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<ExerciseDocument>> GetAll()
    {
        var exercises = await _context.ExerciseDocuments.ToListAsync();
        return exercises;
    }

    public async Task<ExerciseDocument> GetById(int id)
    {
        return await _context.ExerciseDocuments.FindAsync(id);
    }
    public async Task<ExerciseDocument> Create(ExerciseDocument exerciseDocument)
    {
        await _context.ExerciseDocuments.AddAsync(exerciseDocument);
        await _context.SaveChangesAsync();

        return exerciseDocument;
    }

    public async Task Update(ExerciseDocument exerciseDocument)
    {
        _context.ExerciseDocuments.Update(exerciseDocument);
        await _context.SaveChangesAsync();
    }
}