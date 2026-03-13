using Application.CartItems;
using Application.CartItems.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/cart-item")]
[ApiController]
public class CartItemController : ControllerBase
{
    private readonly ICartItemApplication _cartItemApplication;

    public CartItemController(ICartItemApplication cartItemApplication)
    {
        _cartItemApplication = cartItemApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCartItemDto dto)
    {
        var result = await _cartItemApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateCartItemDto dto)
    {
        await _cartItemApplication.Update(id, dto);
        return Ok("Cart Item Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cartItemApplication.Delete(id);
        return Ok("Cart Item Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _cartItemApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _cartItemApplication.GetById(id);

        if (data == null)
            return NotFound("Cart Item not found");

        return Ok(data);
    }
}