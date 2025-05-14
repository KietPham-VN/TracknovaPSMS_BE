namespace Application.DTOs.UserDTO.Requests;

public class UserRegisterRequest
{
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}