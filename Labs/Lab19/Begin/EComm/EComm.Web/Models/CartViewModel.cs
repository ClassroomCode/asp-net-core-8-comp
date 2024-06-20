using System.ComponentModel.DataAnnotations;

namespace EComm.Web.Models;

public record CartViewModel
(
    ShoppingCart? Cart = null,
    [Required]
    string? CustomerName = null,
    [Required]
    [EmailAddress]
    string? Email = null,
    [Required]
    [CreditCard]
    string? CreditCard = null
);
