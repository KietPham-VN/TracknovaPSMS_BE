namespace Infrastructures.Data;

public partial class TracknovaContext : DbContext, IApplicationDbContext
{
    public TracknovaContext()
    {
    }

    public TracknovaContext(DbContextOptions<TracknovaContext> options)
        : base(options)
    {
    }

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=Tracknova_PSMS_DB;user=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("auditlog");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ActionAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ActionBy).HasMaxLength(30);
            entity.Property(e => e.NewData).HasColumnType("json");
            entity.Property(e => e.OldData).HasColumnType("json");
            entity.Property(e => e.RecordId).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.PrioritizeScore).HasDefaultValueSql("'0'");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'actived'")
                .HasColumnType("enum('actived','inactived','deleted')");
        });

        modelBuilder.Entity<Import>(entity =>
        {
            entity.HasKey(e => e.ImportId).HasName("PRIMARY");

            entity.ToTable("import");

            entity.HasIndex(e => e.SupplierId, "SupplierId");

            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','complete','cancelled')");
            entity.Property(e => e.TotalPayment).HasPrecision(10, 2);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Imports)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("import_ibfk_1");
        });

        modelBuilder.Entity<ImportItem>(entity =>
        {
            entity.HasKey(e => e.ImportItemId).HasName("PRIMARY");

            entity.ToTable("importItem");

            entity.HasIndex(e => e.ImportId, "ImportId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.ImportPrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Import).WithMany(p => p.ImportItems)
                .HasForeignKey(d => d.ImportId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("importItem_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.ImportItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("importItem_ibfk_2");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("inventory_ibfk_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.CustomerId, "CustomerId");

            entity.Property(e => e.DiscountType).HasMaxLength(50);
            entity.Property(e => e.DiscountValue).HasPrecision(10, 2);
            entity.Property(e => e.RemainPayment).HasPrecision(10, 2);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','in_debt','completed','cancelled','deleted')");
            entity.Property(e => e.TotalPayment).HasPrecision(10, 2);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("order_ibfk_1");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PRIMARY");

            entity.ToTable("orderItem");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.CustomPrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderItem_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orderItem_ibfk_2");
        });

        modelBuilder.Entity<Pricing>(entity =>
        {
            entity.HasKey(e => e.PricingId).HasName("PRIMARY");

            entity.ToTable("pricing");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.PricingValue).HasPrecision(10, 2);
            entity.Property(e => e.UnitType).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.Pricings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("pricing_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.ScanCode, "ScanCode").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.PrioritizeScore).HasDefaultValueSql("'0'");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'actived'")
                .HasColumnType("enum('actived','inactived','deleted')");

            entity.HasMany(d => d.Categories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "Productcategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("productcategory_ibfk_2"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("productcategory_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProductId", "CategoryId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productcategory");
                        j.HasIndex(new[] { "CategoryId" }, "CategoryId");
                    });

            entity.HasMany(d => d.Suppliers).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "Productsupplier",
                    r => r.HasOne<Supplier>().WithMany()
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("productsupplier_ibfk_2"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("productsupplier_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProductId", "SupplierId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productsupplier");
                        j.HasIndex(new[] { "SupplierId" }, "SupplierId");
                    });
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.Property(e => e.PrioritizeScore).HasDefaultValueSql("'0'");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'actived'")
                .HasColumnType("enum('actived','inactived','deleted')");
            entity.Property(e => e.SupplierName).HasMaxLength(255);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','complete','cancelled')");
            entity.Property(e => e.TransactionType).HasColumnType("enum('payment','refund')");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transaction_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.FullName).HasMaxLength(70);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PrioritizeScore).HasDefaultValueSql("'0'");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("'user'")
                .HasColumnType("enum('admin','user','manager')");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'actived'")
                .HasColumnType("enum('actived','inactived','deleted')");
        });
    }

    public Task<int> SaveChangesAsync()
    {
        Console.WriteLine("SaveChanges");

        return base.SaveChangesAsync();
    }
}