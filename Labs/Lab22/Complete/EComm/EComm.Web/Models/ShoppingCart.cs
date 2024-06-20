using EComm.Core.Entities;
using System.Text;
using System.Text.Json;

namespace EComm.Web.Models;

public class ShoppingCart
{
    public List<LineItem> LineItems { get; set; } = [];
    public string FormattedGrandTotal => $"{LineItems.Sum(i => i.TotalCost):C}";

    public class LineItem
    {
        public required Product Product { get; init; }
        public int Quantity { get; set; }

        public decimal TotalCost => (Product?.UnitPrice ?? 0) * Quantity;
    }

    public static ShoppingCart GetFromSession(ISession session)
    {
        byte[]? data;
        ShoppingCart? cart = null;
        bool b = session.TryGetValue("ShoppingCart", out data);
        if (b) {
            string json = Encoding.UTF8.GetString(data!);
            cart = JsonSerializer.Deserialize<ShoppingCart>(json);
        }
        return cart ?? new ShoppingCart();
    }

    public static void StoreInSession(ShoppingCart cart, ISession session)
    {
        string json = JsonSerializer.Serialize(cart);
        byte[] data = Encoding.UTF8.GetBytes(json);
        session.Set("ShoppingCart", data);
    }
}
