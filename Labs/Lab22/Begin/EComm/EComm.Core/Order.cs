namespace EComm.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderNumber { get; set; }
    public decimal? TotalAmount { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}