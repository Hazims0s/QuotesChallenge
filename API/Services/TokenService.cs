using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
            
        }
        public string CreateToken (AppUser user)
        {
            var claims= new List<Claim> {
                new Claim (ClaimTypes.Email, user.Email ) ,
                new Claim (ClaimTypes.NameIdentifier , user.Id)
            }; 
 
            var credintials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config ["TokenKey"]))
             ,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescirptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims), 
                Expires =  DateTime.UtcNow.AddDays(1),
                SigningCredentials= credintials
            };
            var tokenHandler = new JwtSecurityTokenHandler(); 
          return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescirptor));
        }
    }
}