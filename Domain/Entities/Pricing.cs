namespace Domain.Entities;

public class Pricing
{
    public int PricingId { get; set; }

    public int ProductId { get; set; }

    public decimal PricingValue { get; set; }

    public string? UnitType { get; set; }

    public int? ExchangeQuantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}