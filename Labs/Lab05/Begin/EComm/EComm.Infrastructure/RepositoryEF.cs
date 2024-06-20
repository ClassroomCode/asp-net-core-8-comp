using EComm.Core;
using EComm.Core.Entities;

namespace EComm.Infrastructure;

internal class RepositoryEF : IRepository
{
    public Task AddProduct(Product product)
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

    public Task<Product?> GetProduct(int id, bool includeSupplier = false)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
