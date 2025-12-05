using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LuckyOne.Helper
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string GenerateToken(string Username , Boolean Role)
        { 
            var claim = new List<Claim>
            { 
                new Claim(JwtRegisteredClaimNames.Sub , Username.ToString()),
                 new Claim(JwtRegisteredClaimNames.Sub , Role.ToString())
            };
              
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer : _configuration["Jwt:Issuer"],
                audience : _configuration["Jwt:Audience"],
                claims: claim,
                expires : DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
