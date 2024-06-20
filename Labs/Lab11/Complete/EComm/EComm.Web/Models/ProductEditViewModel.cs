using EComm.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EComm.Web.Models;

public record ProductEditViewModel
(
    int Id,
    string ProductName,
    decimal? UnitPrice,
    string Package,
    bool IsDiscontinued,
    int SupplierId,
    Supplier? Supplier,
    IEnumerable<Supplier>? Suppliers 
)
{
    public IEnumerable<SelectListItem> SupplierItems =>
        Suppliers is null ? Array.Empty<SelectListItem>() :
        Suppliers
            .Select(s => new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString() })
            .OrderBy(item => item.Text);
}
