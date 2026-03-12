using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Exercises;

public class ExerciseRepository:IExerciseRepository
{
    private readonly DataContext _context;

    public ExerciseRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task Delete(int id)    
    {
        var exercises = await _context.Exercises.FindAsync(id);
        _context.Exercises.Remove(exercises);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Exercise>> GetAll()
    {
        var exercises = await _context.Exercises.ToListAsync();
        return exercises;
    }

    public async Task<Exercise> GetById(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }
    public async Task<Exercise> Create(Exercise exercises)
    {
        await _context.Exercises.AddAsync(exercises);
        await _context.SaveChangesAsync();

        return exercises;
    }

    public async Task Update(Exercise exercises)
    {
        _context.Exercises.Update(exercises);
        await _context.SaveChangesAsync();
    }
}