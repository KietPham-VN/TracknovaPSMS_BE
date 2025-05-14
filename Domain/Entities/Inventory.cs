namespace Domain.Entities;

public class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int CurrentQuantity { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}