namespace Application.DTOs.UserDTO.Requests;

public class UserLoginRequest
{
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
}