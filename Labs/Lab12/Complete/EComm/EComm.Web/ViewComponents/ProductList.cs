using EComm.Core;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Web.ViewComponents;

public class ProductList : ViewComponent
{
    private readonly IRepository _repository;
    private readonly ILogger<ProductList> _logger;

    public ProductList(IRepository repository,
                       ILogger<ProductList> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await _repository.GetAllProducts(includeSuppliers: true);
        return View(products);
    }
}
