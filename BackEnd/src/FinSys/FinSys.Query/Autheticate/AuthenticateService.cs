using FinSys.Query.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Autheticate
{
    internal class AuthenticateService : IAutheticate
    {
        private readonly IConfiguration _configuration;
        private readonly IGetSystemUserService _getSystemUserService;

        public AuthenticateService(IConfiguration configuration, IGetSystemUserService getSystemUserService)
        {
            _configuration = configuration;
            _getSystemUserService = getSystemUserService;
        }

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var user =  _getSystemUserService.GetSystemUsersAllAsync().Result.FirstOrDefault(x => x.Name.ToLower() == email.ToLower());

            if (user == null)
            {
                return false;
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return false;
            }

            return true;
        }

        public string GenerateToken(int id, string email)
        {
            var Claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                 issuer: _configuration["jwt:issuer"],
                 audience: _configuration["jwt:audience"],
                 claims: Claims,
                 expires: expiration,
                 signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> UserExists(string email)
        {
            var user = _getSystemUserService.GetSystemUsersAllAsync().Result.FirstOrDefault(x => x.Name.ToLower() == email.ToLower());

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
