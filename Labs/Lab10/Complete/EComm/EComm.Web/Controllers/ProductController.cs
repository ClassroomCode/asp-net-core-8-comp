using EComm.Core;
using EComm.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Web.Controllers;

public class ProductController : Controller
{
    private readonly IRepository _repository;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IRepository repository,
                             ILogger<ProductController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _repository.GetProduct(id, includeSupplier: true);
        return View(product);
    }

    [HttpGet("product/edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _repository.GetProduct(id, includeSupplier: true);
        var suppliers = await _repository.GetAllSuppliers();

        var pvm = new ProductEditViewModel(
            Id: product.Id,
            ProductName: product.ProductName,
            UnitPrice: product.UnitPrice,
            Package: product.Package,
            IsDiscontinued: product.IsDiscontinued,
            SupplierId: product.SupplierId,
            Supplier: product.Supplier,
            Suppliers: suppliers
        );
        return View(pvm);
    }
}
