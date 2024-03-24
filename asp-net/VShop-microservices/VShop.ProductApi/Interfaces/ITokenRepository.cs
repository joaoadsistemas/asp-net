using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VShop.ProductApi.Interfaces
{
    public interface ITokenRepository
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);

    }
}
