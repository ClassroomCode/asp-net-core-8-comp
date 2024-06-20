using EComm.Core;
using EComm.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure;

public static class RepositoryFactory
{
    public static IRepository Create(string connStr) =>
      new RepositoryEF(connStr);
}

internal class RepositoryEF : DbContext, IRepository
{
    private readonly string _connStr;

    public RepositoryEF(string connStr)
    {
        _connStr = connStr;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connStr);
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false)
    {
        return includeSuppliers switch {
            true => await Products.Include(p => p.Supplier).ToListAsync(),
            false => await Products.ToListAsync()
        };
    }

    public Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetProduct(int id, bool includeSupplier = false)
    {
        return includeSupplier switch {
            true => await Products.Include(p => p.Supplier)
                    .SingleOrDefaultAsync(p => p.Id == id),
            false => await Products.SingleOrDefaultAsync(p => p.Id == id)
        };
    }

    public Task<bool> SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
