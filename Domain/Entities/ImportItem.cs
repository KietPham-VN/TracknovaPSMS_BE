namespace Domain.Entities;

public class ImportItem
{
    public int ImportItemId { get; set; }

    public int? ImportId { get; set; }

    public int? ProductId { get; set; }

    public int? ImportQuantity { get; set; }

    public decimal? ImportPrice { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual Import? Import { get; set; }

    public virtual Product? Product { get; set; }
}