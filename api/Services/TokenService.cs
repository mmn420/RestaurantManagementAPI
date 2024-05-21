using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _usermanager;

        public TokenService(IConfiguration config, UserManager<User> usermanager)
        {
            _config = config;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
            _usermanager = usermanager;
        }

        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            new Claim(ClaimTypes.Role, await GetRole(user))
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<string?> GetRole(User user)
        {
            var role = await _usermanager.GetRolesAsync(user);
            return role.FirstOrDefault().ToString();
        }
    }
}