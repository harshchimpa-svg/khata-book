using Application.Exercises;
using Application.Exercises.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseApplication _exerciseApplication;

        public ExerciseController(IExerciseApplication exerciseApplication)
        {
            _exerciseApplication = exerciseApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseDto dto)
        {
            var result = await _exerciseApplication.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateExerciseDto dto)    
        {
            await _exerciseApplication.Update(id, dto);
            return Ok("Exercise Updated"); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseApplication.Delete(id);
            return Ok("Exercise Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseApplication.GetAll();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exercise = await _exerciseApplication.GetById(id);
            if (exercise == null) return NotFound("Exercise not found");

            return Ok(exercise);
        }
    }
}