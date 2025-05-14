namespace Application.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string phoneNumber);

    Task<int> AddUserAsync(User user);
}