namespace Domain.Entities;

public class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public ushort? PrioritizeScore { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Import> Imports { get; set; } = new List<Import>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}