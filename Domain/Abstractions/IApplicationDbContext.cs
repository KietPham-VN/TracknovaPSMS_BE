namespace Domain.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<AuditLog> AuditLogs { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Import> Imports { get; set; }

    public DbSet<ImportItem> ImportItems { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Pricing> Pricings { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<User> Users { get; set; }

    public Task<int> SaveChangesAsync();
}