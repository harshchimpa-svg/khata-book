using Application.SalePayments;
using Application.SalePayments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/sale-payment")]
[ApiController]
public class SalePaymentController : ControllerBase
{
    private readonly ISalePaymentApplication _salePaymentApplication;

    public SalePaymentController(ISalePaymentApplication salePaymentApplication)
    {
        _salePaymentApplication = salePaymentApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSalePaymentDto dto)
    {
        var result = await _salePaymentApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateSalePaymentDto dto)
    {
        await _salePaymentApplication.Update(id, dto);
        return Ok("Sale Payment Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _salePaymentApplication.Delete(id);
        return Ok("Sale Payment Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _salePaymentApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _salePaymentApplication.GetById(id);

        if (data == null)
            return NotFound("Sale Payment not found");

        return Ok(data);
    }
}