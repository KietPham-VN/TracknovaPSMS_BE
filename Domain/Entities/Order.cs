namespace Domain.Entities;

public class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? TotalPayment { get; set; }

    public decimal? RemainPayment { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public string? Status { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];

    public virtual ICollection<Transaction> Transactions { get; set; } = [];
}