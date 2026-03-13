using Application.DietDocuments;
using Application.DietDocuments.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/diet-document")]
    [ApiController]
    public class DietDocumentController : ControllerBase
    {
        private readonly IDietDocumentApplication _dietDocumentApp;

        public DietDocumentController(IDietDocumentApplication dietDocumentApp)
        {
            _dietDocumentApp = dietDocumentApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateDietDocumentDto dto)
        {
            var result = await _dietDocumentApp.Create(dto);
            return Ok(new { message = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateDietDocumentDto dto)
        {
            try
            {
                await _dietDocumentApp.Update(id, dto);
                return Ok(new { message = "Diet Document Updated" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dietDocumentApp.Delete(id);
            return Ok(new { message = "Diet Document Deleted" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _dietDocumentApp.GetAll();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _dietDocumentApp.GetById(id);
            if (document == null) return NotFound(new { message = "Diet Document not found" });
            return Ok(document);
        }
    }
}