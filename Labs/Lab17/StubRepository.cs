using EComm.Core;
using EComm.Core.Entities;

namespace EComm.Tests;

public class StubRepository : IRepository
{
    public async Task<Product?> GetProduct(int id, bool includeSuppliers = false)
    {
        var product = new Product {
            Id = 1,
            ProductName = "Bread",
            UnitPrice = 15.00M,
            Package = "Bag",
            IsDiscontinued = false,
            SupplierId = 1
        };
        if (includeSuppliers) {
            product.Supplier = new Supplier {
                Id = 1,
                CompanyName = "Acme, Inc."
            };
        }
        return await Task.Run(() => product);
    }

    public Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    Task<bool> IRepository.SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        throw new NotImplementedException();
    }
}
