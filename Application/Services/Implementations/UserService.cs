using Application.DTOs.UserDTO.Requests;
using Application.Helpers;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Enums;

namespace Application.Services.Implementations;

public class UserService(IUserRepository userRepo) : IUserService
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
}