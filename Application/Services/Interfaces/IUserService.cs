using Application.DTOs.UserDTO.Requests;
using Application.DTOs.UserDTO.Response;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task<int> RegisterAsync(UserRegisterRequest request);

    Task<UserLoginResponse> LoginAsync(UserLoginRequest request);

    Task<UserLoginResponse> RefreshTokenAsync(RefreshTokenRequest request);
}