using ApiFoundation.NET.Dtos;
using ApiFoundation.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFoundation.NET.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _service.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var product = _service.GetById(id);
        if (product is null)
            return NotFound("Product not found");

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductDto dto)
    {
        var created = _service.Create(dto);

        return CreatedAtAction(nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] UpdateProductDto dto)
    {
        var updated = _service.Update(id, dto);

        if (!updated)
            return NotFound("Product not found");

        return Ok("Product updated");
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _service.Delete(id);

        if (!deleted)
            return NotFound("Product not found");

        return Ok("Product deleted");
    }
}