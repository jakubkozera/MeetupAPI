using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetupAPI.Entities;
using Microsoft.IdentityModel.Tokens;

namespace MeetupAPI.Identity
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("BirthOfDate", user.DateOfBirth.Value.ToString("dd-MM-yyyy")),
                new Claim("Nationality", user.Nationality)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(_jwtOptions.JwtExpireDays);

            var token = new JwtSecurityToken(
                _jwtOptions.JwtIssuer,
                _jwtOptions.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
