namespace Domain.Entities;

public class Transaction
{
    public int TransactionId { get; set; }

    public int? OrderId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }
}