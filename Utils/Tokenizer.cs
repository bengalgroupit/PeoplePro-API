using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PeoplePro.Utils;

public class Tokenizer(Settings settings)
{
    public string GenerateToken(string empCode)
    {
        try
        {
            var claims = new List<Claim>
            {
                new("EmpCode", empCode),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(60),
                Issuer = settings.Issuer,
                Audience =  settings.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here
            throw new ApplicationException("Failed to generate token.", ex);
        }
    }
}