using Application.GymDocuments;
using Application.GymDocuments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/gym-document")]
[ApiController]
public class GymDocumentController : ControllerBase
{
    private readonly IGymDocumentApplication _gymDocumentApplication;

    public GymDocumentController(IGymDocumentApplication gymDocumentApplication)
    {
        _gymDocumentApplication = gymDocumentApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateGymDocumentDto dto)
    {
        var result = await _gymDocumentApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateGymDocumentDto dto)
    {
        await _gymDocumentApplication.Update(id, dto);
        return Ok("Gym Document Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _gymDocumentApplication.Delete(id);
        return Ok("Gym Document Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _gymDocumentApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _gymDocumentApplication.GetById(id);

        if (data == null)
            return NotFound("Gym Document not found");

        return Ok(data);
    }
}