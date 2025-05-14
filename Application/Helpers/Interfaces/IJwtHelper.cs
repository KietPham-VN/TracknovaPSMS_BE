namespace Application.Helpers.Interfaces;

public interface IJwtHelper
{
    string GenerateAccessToken(User user);

    string GenerateRefreshToken();
}