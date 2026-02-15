using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.DTOs;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET /products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();

        return Ok(products);
    }

    // GET /products/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);

         if (product == null)
         {

            return NotFound($"Product with id {id} not found");
         }

        return Ok(product);
    }


    // POST /products
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var createdProduct = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById),new { id = createdProduct.Id }, createdProduct);
    }


    // PUT /products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound($"Product with id {id} not found");
        }

        return NoContent();
    }


    // DELETE /products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound($"Product with id {id} not found");
        }

        return NoContent();
    }

}
