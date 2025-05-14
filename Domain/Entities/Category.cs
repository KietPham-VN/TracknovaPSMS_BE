namespace Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public ushort? PrioritizeScore { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}