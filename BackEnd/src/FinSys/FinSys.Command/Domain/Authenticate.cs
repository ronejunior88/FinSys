using FinSys.Command.Interfaces;
using FinSys.Query.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FinSys.Command.Domain
{
    public class Authenticate : IAuthenticate
    {
        private readonly IConfiguration _configuration;
        private readonly IGetSystemUserService _getSystemUserService;

        public Authenticate(IConfiguration configuration, IGetSystemUserService getSystemUserService)
        {
            _configuration = configuration;
            _getSystemUserService = getSystemUserService;
        }

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var user = _getSystemUserService.GetSystemUsersAllAsync().Result.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

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

        public string GenerateToken(Guid id, string email)
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
            var user = _getSystemUserService.GetSystemUsersAllAsync().Result.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Guid> GetUserByEmail(string email)
        {
            var user = _getSystemUserService.GetSystemUsersAllAsync().Result.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

            return user.Id;
        }
    }
}
