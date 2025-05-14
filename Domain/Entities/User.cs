using Domain.Enums;

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

    public UserRole Role { get; set; } = UserRole.User;

    public UserStatus Status { get; set; } = UserStatus.Activated;

    public ushort? PrioritizeScore { get; set; } = 0;

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
}