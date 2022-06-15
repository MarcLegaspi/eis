using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string CreateToken(string email, string role)
        {
            var claims = new Claim[]{
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            var tokenExpirationHours = Convert.ToInt32(_configuration["Token:ExpirationHours"]);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor() 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(tokenExpirationHours),
                SigningCredentials = creds,
                Issuer = _configuration["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}