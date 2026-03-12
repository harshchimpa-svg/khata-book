using Application.Gyms;
using Application.Gyms.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GymController : ControllerBase
{
    private readonly IGymApplication _gymApplication;

    public GymController(IGymApplication gymApplication)
    {
        _gymApplication = gymApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGymDto dto)
    {
        var result = await _gymApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateGymDto dto)
    {
        await _gymApplication.Update(id, dto);
        return Ok("Gym Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _gymApplication.Delete(id);
        return Ok("Gym Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _gymApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _gymApplication.GetById(id);

        if (data == null)
            return NotFound("Gym not found");

        return Ok(data);
    }
}