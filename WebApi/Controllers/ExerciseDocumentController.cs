using Application.ExerciseDocuments;
using Application.ExerciseDocuments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseDocumentController : ControllerBase
    {
        private readonly IExerciseDocumentApplication _exerciseDocumentApplication;

        public ExerciseDocumentController(IExerciseDocumentApplication exerciseDocumentApplication)
        {
            _exerciseDocumentApplication = exerciseDocumentApplication;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateExerciseDocumentDto dto)
        {
            var result = await _exerciseDocumentApplication.Create(dto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateExerciseDocumentDto dto)
        {
            await _exerciseDocumentApplication.Update(id, dto);
            return Ok("Exercise Document Updated");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseDocumentApplication.Delete(id);
            return Ok("Exercise Document Deleted");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _exerciseDocumentApplication.GetAll();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _exerciseDocumentApplication.GetById(id);

            if (document == null)
                return NotFound("Exercise Document not found");

            return Ok(document);
        }
    }
}