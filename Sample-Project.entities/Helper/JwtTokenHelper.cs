
using Microsoft.IdentityModel.Tokens;
using Sample_Project.entities.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Sample_Project.entities.Helper
{
    public static class JwtTokenHelper
    {
        public static string GenerateToken(JwtSetting jwtSetting, SessionDetailsViewModel userSessionDetails)
        {
            if (jwtSetting == null)
                return string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {

            new Claim(ClaimTypes.Name, userSessionDetails.UserId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, userSessionDetails.UserId.ToString()),

            new Claim(ClaimTypes.Role, userSessionDetails.UserRole),
            new Claim("CustomClaimForUser", JsonSerializer.Serialize(userSessionDetails))
            }; // Additional Claims

            var token = new JwtSecurityToken(

            jwtSetting.Issuer,

            jwtSetting.Audience,

            claims,

            expires: DateTime.UtcNow.AddHours(2),

            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
