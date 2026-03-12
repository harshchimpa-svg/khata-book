using Application.Exercises.Dto;
using Data.Exercises; 
using Domain;

namespace Application.Exercises
{
    public class ExerciseApplication : IExerciseApplication
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseApplication(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<string> Create(CreateErciseDto dto)
        {
            var exercise = new Exercise
            {
                DietTypeId = dto.DietTypeId,
                Name = dto.Name,
                Description = dto.Description
            };

            await _exerciseRepository.Create(exercise);
            return "Exercise Created";
        }

        public async Task Update(int id, CreateErciseDto dto)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise == null) throw new Exception("Exercise not found");

            exercise.DietTypeId = dto.DietTypeId;
            exercise.Name = dto.Name;
            exercise.Description = dto.Description;

            await _exerciseRepository.Update(exercise);
        }

        public async Task Delete(int id)
        {
            await _exerciseRepository.Delete(id);
        }

        public async Task<List<ExerciseDto>> GetAll()
        {
            var exercises = await _exerciseRepository.GetAll();

            return exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                DietTypeId = e.DietTypeId,
                Name = e.Name,
                Description = e.Description
            }).ToList();
        }

        public async Task<ExerciseDto> GetById(int id)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise == null) return null;

            return new ExerciseDto
            {
                Id = exercise.Id,
                DietTypeId = exercise.DietTypeId,
                Name = exercise.Name,
                Description = exercise.Description
            };
        }
    }
}