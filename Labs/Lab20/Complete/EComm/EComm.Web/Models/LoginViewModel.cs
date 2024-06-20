using System.ComponentModel.DataAnnotations;

namespace EComm.Web.Models;

public record LoginViewModel
(
    [Required]
    string Username = "",
    [Required]
    [DataType(DataType.Password)]
    string Password = "",
    string ReturnUrl = ""
);
