using EComm.Core;
using EComm.Core.Entities;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _repository.GetProduct(id);
        if (product is null) return NotFound();
        return Ok(product);
    }
}
