using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Entities.FileEntities;
using ECommerceAPI.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Contexts;

//public class ECommerceAPIDbContext : DbContext
public class ECommerceAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ECommerceAPIDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }

    public DbSet<BaseFile> BaseFiles { get; set; }
    public DbSet<ProductImageFile> ProductImageFiles { get; set; }
    public DbSet<InvoiceFile> InvoiceFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // for define one to one relationship between Basket and Order 
        builder.Entity<Order>()
            .HasKey(b => b.Id);

        builder.Entity<Order>()
            .HasIndex(o => o.OrderCode)
            .IsUnique();
        
        builder.Entity<Basket>()
            .HasOne(b => b.Order)
            .WithOne(o => o.Basket)
            .HasForeignKey<Order>(b => b.Id);
        
        builder.Entity<Order>()
            .HasOne(o => o.CompletedOrder)
            .WithOne(c => c.Order)
            .HasForeignKey<CompletedOrder>(c => c.OrderId);
        
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow,
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}