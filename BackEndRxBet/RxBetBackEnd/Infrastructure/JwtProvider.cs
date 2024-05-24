using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using RxBetDataBase.Models;
using RxBetAuthorization.Interfaces.Auth;

namespace Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtOptions _options;
        public JwtProvider(IJwtOptions options) 
        {
            _options = options;
        }
        public string GenerateToken(UserEntity user) // TODO: roles, userID, expired_at (exp)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                    SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.UtcNow.AddHours(_options.ExpireHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
