using Application.locations;
using Application.locations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationApplications _locationApplication;

    public LocationController(ILocationApplications locationApplication)
    {
        _locationApplication = locationApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create( CreateLocationDto dto)
    {
        var result = await _locationApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLocationDto dto)
    {
        await _locationApplication.Update(id, dto);
        return Ok("Location Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationApplication.Delete(id);
        return Ok("Location Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _locationApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _locationApplication.GetById(id);

        if (data == null)
            return NotFound("Location not found");

        return Ok(data);
    }
}