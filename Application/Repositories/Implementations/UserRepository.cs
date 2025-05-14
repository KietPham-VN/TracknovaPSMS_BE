using Application.Repositories.Interfaces;

namespace Application.Repositories.Implementations;

public class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber).ConfigureAwait(false);
    }

    public async Task<int> AddUserAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync().ConfigureAwait(false);
        return user.UserId;
    }

    public async Task UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken).ConfigureAwait(false);
    }
}