using Application.Categories;
using Application.Categories.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManjeetFigma.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApp;

        public CategoryController(ICategoryApplication categoryApp)
        {
            _categoryApp = categoryApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto dto)
        {
            var result = await _categoryApp.Create(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryApp.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryApp.GetById(id);
            if (category == null)
                return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateCategoryDto dto)
        {
            await _categoryApp.Update(id, dto);
            return Ok("Category updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApp.Delete(id);
            return Ok("Category deleted");
        }
    }
}