namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Role { get; set; }

    public ushort? PrioritizeScore { get; set; }

    public string? Status { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = [];
}