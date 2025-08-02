using ePharmacy.Application.Dtos.UserDtos;
using System.Security.Claims;

namespace ePharmacy.Application.Services.TokenService;

public interface ITokenService
{
    public string GenerateToken(UserDto userDto);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    public string RemoveRefreshTokenAsync(string token);
}