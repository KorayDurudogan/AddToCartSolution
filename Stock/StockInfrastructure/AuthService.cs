using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration) => _configuration = configuration;

        public async Task<string> CreateToken(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            else if (!password.Equals(_configuration.GetSection(StockConstants.TokenPassword).Value))
                throw new UnauthorizedAccessException();

            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetSection(StockConstants.TokenIssuer).Value,
                audience: _configuration.GetSection(StockConstants.TokenKey).Value,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection(StockConstants.TokenSigningKey).Value)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
