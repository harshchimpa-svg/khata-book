using Application.Dites;
using Application.Dites.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ManjeetFigma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IDiteApplication _dietApp;

        public DietController(IDiteApplication dietApp)
        {
            _dietApp = dietApp;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateDietDto dto)
        {
            var result = await _dietApp.Create(dto);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var diets = await _dietApp.GetAll();
            return Ok(diets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diet = await _dietApp.GetById(id);
            if (diet == null)
                return NotFound("Diet not found");

            return Ok(diet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDietDto dto)
        {
            await _dietApp.Update(id, dto);
            return Ok("Diet updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dietApp.Delete(id);
            return Ok("Diet deleted");
        }
    }
}