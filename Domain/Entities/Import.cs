namespace Domain.Entities;

public class Import
{
    public int ImportId { get; set; }

    public int? SupplierId { get; set; }

    public decimal? TotalPayment { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ImportItem> ImportItems { get; set; } = [];

    public virtual Supplier? Supplier { get; set; }
}