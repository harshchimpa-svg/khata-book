using Application.Memberships;
using Application.Memberships.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/membership")]
[ApiController]
public class MembershipController : ControllerBase
{
    private readonly IMembershipApplication _membershipApplication;

    public MembershipController(IMembershipApplication membershipApplication)
    {
        _membershipApplication = membershipApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMembershipDto dto)
    {
        var result = await _membershipApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateMembershipDto dto)
    {
        await _membershipApplication.Update(id, dto);
        return Ok("Membership Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _membershipApplication.Delete(id);
        return Ok("Membership Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _membershipApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _membershipApplication.GetById(id);

        if (data == null)
            return NotFound("Membership not found");

        return Ok(data);
    }
}