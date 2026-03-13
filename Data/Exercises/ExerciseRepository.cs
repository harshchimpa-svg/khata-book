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
        var exercise = await _context.Exercises.FindAsync(id);
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();   
    }
    public async Task<List<Exercise>> GetAll()
    {
        var exercise = await _context.Exercises.ToListAsync();
        return exercise;
    }

    public async Task<Exercise> GetById(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }
    public async Task<Exercise> Create(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }

    public async Task Update(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }
}