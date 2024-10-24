using Microsoft.EntityFrameworkCore;
using StoreCashFlow.Domain.Entity;

namespace StoreCashFlow.Domain.Context;

/// <summary>
///     Класс для доступа к базе данных
/// </summary>
public class StoreCashFlowDbContext(DbContextOptions<StoreCashFlowDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAvailability> ProductAvailability { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<Store> Store { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductType>().HasData(
           new ProductType { Id = 1, Name = "Штучный" },
           new ProductType { Id = 2, Name = "Развесной" }
        );
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Barcode);
        modelBuilder.Entity<Product>()
            .Navigation(p => p.ProductType)
            .AutoInclude();
        modelBuilder.Entity<ProductAvailability>()
            .Navigation(p => p.Product)
            .AutoInclude();
        modelBuilder.Entity<ProductAvailability>()
            .Navigation(p => p.Store)
            .AutoInclude();
        modelBuilder.Entity<Sale>()
            .Navigation(p => p.Product)
            .AutoInclude();
        modelBuilder.Entity<Sale>()
            .Navigation(p => p.Store)
            .AutoInclude();
        modelBuilder.Entity<Sale>()
            .Navigation(p => p.Customer)
            .AutoInclude();
    }
}
