using Application.DTOs.UserDTO.Requests;
using Application.DTOs.UserDTO.Response;
using Application.Helpers;
using Application.Helpers.Interfaces;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Enums;

namespace Application.Services.Implementations;

public class UserService(IUserRepository userRepo, IJwtHelper jwtHelper) : IUserService
{
    public async Task<int> RegisterAsync(UserRegisterRequest request)
    {
        var existingUser = await userRepo.GetByPhoneNumberAsync(request.PhoneNumber).ConfigureAwait(false);
        if (existingUser != null)
        {
            throw new Exception("Phone number already exists.");
        }

        var hashedPassword = PasswordHasher.Hash(request.Password);

        var user = new User
        {
            PhoneNumber = request.PhoneNumber,
            Password = hashedPassword,
            FullName = request.FullName,
            Email = request.Email,
            Address = request.Address,
            DateOfBirth = request.DateOfBirth,
            Status = UserStatus.Activated,
            Role = UserRole.User
        };

        return await userRepo.AddUserAsync(user).ConfigureAwait(false);
    }

    public async Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
    {
        var user = await userRepo.GetByPhoneNumberAsync(request.PhoneNumber).ConfigureAwait(false)
            ?? throw new Exception("Invalid credentials");

        if (!PasswordHasher.Verify(request.Password, user.Password))
            throw new Exception("Invalid credentials");

        var accessToken = jwtHelper.GenerateAccessToken(user);
        var refreshToken = jwtHelper.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = DateTime.UtcNow.AddDays(7);

        await userRepo.UpdateUserAsync(user).ConfigureAwait(false);

        return new UserLoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpiration = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<UserLoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var user = await userRepo.GetByRefreshTokenAsync(request.RefreshToken).ConfigureAwait(false)
                   ?? throw new Exception("Invalid refresh token");

        if (user.RefreshTokenExpiration < DateTime.UtcNow)
            throw new Exception("Refresh token expired");

        var newAccessToken = jwtHelper.GenerateAccessToken(user);
        var newRefreshToken = jwtHelper.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiration = DateTime.UtcNow.AddDays(7);
        await userRepo.UpdateUserAsync(user).ConfigureAwait(false);

        return new UserLoginResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            AccessTokenExpiration = DateTime.UtcNow.AddMinutes(60)
        };
    }
}