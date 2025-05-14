using Application.DTOs.UserDTO.Requests;

namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task<int> RegisterAsync(UserRegisterRequest request);
}


