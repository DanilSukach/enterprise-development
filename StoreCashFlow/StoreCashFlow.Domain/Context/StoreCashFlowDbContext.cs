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
            .HasOne(p => p.ProductType)
                .WithOne()
                .HasForeignKey<Product>("product_type")
                .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductAvailability>()
            .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductAvailability>()
            .HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Sale>()
            .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Sale>()
            .HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Sale>()
            .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey("customer_id")
                .OnDelete(DeleteBehavior.Cascade);
    }
}
