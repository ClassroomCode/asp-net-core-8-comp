using EComm.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EComm.Web.Models;

public record ProductEditViewModel
(
    int Id,
    [Required(ErrorMessage ="A product must have a name")] 
    string ProductName,
    [Required(ErrorMessage = "A product must have a price")]
    [Range(1.0, 500.0, ErrorMessage = "Price of a product must be between 1 and 500")]
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
