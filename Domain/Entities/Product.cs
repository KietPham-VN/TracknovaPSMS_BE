namespace Domain.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string ScanCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public ushort? PrioritizeScore { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ImportItem> ImportItems { get; set; } = [];

    public virtual ICollection<Inventory> Inventories { get; set; } = [];

    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];

    public virtual ICollection<Pricing> Pricings { get; set; } = [];

    public virtual ICollection<Category> Categories { get; set; } = [];

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}