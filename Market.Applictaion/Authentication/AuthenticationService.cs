using Market.Applictaion.DTOs;
using Market.Applictaion.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Market.Applictaion.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthOptions _authOptions;
        public AuthenticationService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        public string Authenticate(UserDTO user)
        {
            var currentUser = _authOptions.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (currentUser == null)
            {
                return null;
            }

            return GenerateJwtToken(currentUser);
        }

        private string GenerateJwtToken(UserIdentity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
