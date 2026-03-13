using Application.GymProducts;
using Application.GymProducts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/gym-product")]
[ApiController]
public class GymProductController : ControllerBase
{
    private readonly IGymProductApplication _gymProductApplication;

    public GymProductController(IGymProductApplication gymProductApplication)
    {
        _gymProductApplication = gymProductApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGymProductDto dto)
    {
        var result = await _gymProductApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateGymProductDto dto)
    {
        await _gymProductApplication.Update(id, dto);
        return Ok("Gym Product Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _gymProductApplication.Delete(id);
        return Ok("Gym Product Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _gymProductApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _gymProductApplication.GetById(id);

        if (data == null)
            return NotFound("Gym Product not found");

        return Ok(data);
    }
}