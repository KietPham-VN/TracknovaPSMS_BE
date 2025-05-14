namespace Application.Services.Interfaces;

public interface IUserService
{
    public Task<int> RegisterAsync(string phoneNumber, string password);
}


