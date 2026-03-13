using Application.DiteTypes;
using Application.DiteTypes.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/diet-type")]
[Authorize]
public class DietTypeController : ControllerBase
{
    private readonly IDietTypeApplication _dietTypeApplication;

    public DietTypeController(IDietTypeApplication dietTypeApplication)
    {
        _dietTypeApplication = dietTypeApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDietTypeDto input)
    {
        var result = await _dietTypeApplication.Create(input);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _dietTypeApplication.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _dietTypeApplication.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateDietTypeDto input)
    {
        await _dietTypeApplication.Update(id, input);
        return Ok("Diet Type Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _dietTypeApplication.Delete(id);
        return Ok("Diet Type Deleted");
    }
}