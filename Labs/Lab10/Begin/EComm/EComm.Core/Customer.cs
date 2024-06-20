namespace EComm.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
}