using Application.Sales;
using Application.Sales.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/sale")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleApplication _saleApplication;

    public SaleController(ISaleApplication saleApplication)
    {
        _saleApplication = saleApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSaleDto dto)
    {
        var result = await _saleApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateSaleDto dto)
    {
        await _saleApplication.Update(id, dto);
        return Ok("Sale Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _saleApplication.Delete(id);
        return Ok("Sale Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _saleApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _saleApplication.GetById(id);

        if (data == null)
            return NotFound("Sale not found");

        return Ok(data);
    }
}