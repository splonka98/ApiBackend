using AppCore.Interfaces;
using AppCore.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        
        public string GenerateJwt()
        {
            throw new NotImplementedException();
        }

        public User RegisterUser(string email, string password, string firstName, string lastName, int roleId)
        {
            return new User()
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                RoleId = roleId
            };
        }
        public string GenerateJwt(string email, string password, User User, IConfiguration configuration )
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                new Claim(ClaimTypes.Role, $"{User.RoleId}"),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                         configuration["Jwt:Issuer"],
                         configuration["Jwt:Audience"],
                         claims,
                         expires: DateTime.UtcNow.AddMinutes(10),
                         signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            var dupa = tokenHandler.WriteToken(token);
            var dupa1 = tokenHandler.ReadToken(dupa);


            return dupa;

        }
    }
}
