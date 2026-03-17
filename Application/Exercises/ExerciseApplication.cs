using Application.Exercises.Dto;
using AutoMapper;
using Data.Exercises;
using Domain;

namespace Application.Exercises
{
    public class ExerciseApplication : IExerciseApplication
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseApplication(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateExerciseDto dto)
        {
            var exercise = _mapper.Map<Exercise>(dto);

            await _exerciseRepository.Create(exercise);

            return "Exercise Created";
        }

        public async Task Update(int id, CreateExerciseDto dto)
        {
            var exercise = await _exerciseRepository.GetById(id);

            if (exercise == null)
                throw new Exception("Exercise not found");

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

            return _mapper.Map<List<ExerciseDto>>(exercises);
        }

        public async Task<ExerciseDto> GetById(int id)
        {
            var exercise = await _exerciseRepository.GetById(id);

            if (exercise == null)
                return null;

            return _mapper.Map<ExerciseDto>(exercise);
        }
    }
}