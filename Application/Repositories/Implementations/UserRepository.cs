using Application.Repositories.Interfaces;

namespace Application.Repositories.Implementations;

public class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string phoneNumber)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task<int> AddUserAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user.UserId;
    }
}