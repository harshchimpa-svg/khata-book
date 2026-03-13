using Application.SaleProducts;
using Application.SaleProducts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/sale-product")]
[ApiController]
public class SaleProductController : ControllerBase
{
    private readonly ISaleProductApplication _saleProductApplication;

    public SaleProductController(ISaleProductApplication saleProductApplication)
    {
        _saleProductApplication = saleProductApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSaleProductDto dto)
    {
        var result = await _saleProductApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateSaleProductDto dto)
    {
        await _saleProductApplication.Update(id, dto);
        return Ok("Sale Product Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _saleProductApplication.Delete(id);
        return Ok("Sale Product Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _saleProductApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _saleProductApplication.GetById(id);

        if (data == null)
            return NotFound("Sale Product not found");

        return Ok(data);
    }
}