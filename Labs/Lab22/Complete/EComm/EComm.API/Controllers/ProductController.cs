using EComm.Core;
using EComm.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComm.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IRepository _repository;

    public ProductController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet()]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _repository.GetAllProducts();
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "AdminsOnly")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct(int id, 
        [FromHeader(Name = "X-PSK")] string? psk = null)
    {
        var product = await _repository.GetProduct(id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id) return BadRequest();

        bool b = await _repository.SaveProduct(product);
        if (!b) return NotFound();

        return NoContent();
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _repository.AddProduct(product);
        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _repository.GetProduct(id);
        if (product is null) return NotFound();
        await _repository.DeleteProduct(product);
        return NoContent();
    }
}
