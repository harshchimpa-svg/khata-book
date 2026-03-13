using Application.ProductDocuments;
using Application.ProductDocuments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/product-document")]
[ApiController]
public class ProductDocumentController : ControllerBase
{
    private readonly IProductDocumentApplication _productDocumentApplication;

    public ProductDocumentController(IProductDocumentApplication productDocumentApplication)
    {
        _productDocumentApplication = productDocumentApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductDocumentDto dto)
    {
        var result = await _productDocumentApplication.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] CreateProductDocumentDto dto)
    {
        await _productDocumentApplication.Update(id, dto);
        return Ok("Product Document Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productDocumentApplication.Delete(id);
        return Ok("Product Document Deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _productDocumentApplication.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _productDocumentApplication.GetById(id);

        if (data == null)
            return NotFound("Product Document not found");

        return Ok(data);
    }
}