namespace Application.DTOs.UserDTO.Response;

public class UserLoginResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}