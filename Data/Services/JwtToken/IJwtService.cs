using Domain;

namespace Data.Services.JwtToken;

public interface IJwtService
{
    string GenerateToken(User user);
}