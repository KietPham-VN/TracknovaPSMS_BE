using Application.Repositories.Interfaces;
using Application.Services.Interfaces;

namespace Application.Services.Implementations;

public class UserService(IUserRepository userRepo) : IUserService
{
    public async Task<int> RegisterAsync(string phoneNumber, string password)
    {
        var existingUser = await userRepo.GetByUsernameAsync(phoneNumber).ConfigureAwait(false);
        if (existingUser != null)
        {
            throw new Exception("Phone number already exists.");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            PhoneNumber = phoneNumber,
            Password = hashedPassword,
            Status = "actived"
        };

        return await userRepo.AddUserAsync(user).ConfigureAwait(false);
    }
}