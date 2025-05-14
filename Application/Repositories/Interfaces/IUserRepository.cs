namespace Application.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetByPhoneNumberAsync(string phoneNumber);

    public Task<int> AddUserAsync(User user);

    public Task UpdateUserAsync(User user);

    public Task<User?> GetByRefreshTokenAsync(string refreshToken);
}