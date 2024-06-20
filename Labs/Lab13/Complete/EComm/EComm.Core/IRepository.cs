using EComm.Core.Entities;

namespace EComm.Core;

public interface IRepository
{
    Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false);
    Task<Product?> GetProduct(int id, bool includeSupplier = false);
    Task<IEnumerable<Supplier>> GetAllSuppliers();
    Task<bool> SaveProduct(Product product);
    Task AddProduct(Product product);
    Task<bool> DeleteProduct(Product product);
}