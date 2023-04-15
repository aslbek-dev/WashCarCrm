using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly TokenConfiguration tokenConfiguration;

        public TokenRepository(IConfiguration configuration)
        {
            this.tokenConfiguration = new TokenConfiguration();
            configuration.Bind("JWT", this.tokenConfiguration);
        }
        public string GenerateJWT(User user)
        {
            byte[] convertedKeyToBytes =
                Encoding.UTF8.GetBytes(this.tokenConfiguration.Key);

            var securityKey =
                new SymmetricSecurityKey(convertedKeyToBytes);

            var cridentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
             var token = new JwtSecurityToken(
                this.tokenConfiguration.Issuer,
                this.tokenConfiguration.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cridentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}