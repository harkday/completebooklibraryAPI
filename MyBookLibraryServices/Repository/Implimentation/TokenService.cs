using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBookLibraryModel.Model;
using MyBookLibraryServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryServices.Repository.Implimentation
{
    public class TokenService : ITokenService
    {

        private readonly SymmetricSecurityKey _Key;
        private readonly IConfiguration Config;

        public TokenService(IConfiguration config)
        {
            _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            Config = config;
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>


                {
                    new Claim(JwtRegisteredClaimNames.NameId,user.FirstName)

                };

            var creds = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(User user, List<string> userRoles)
        {
            // add claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            };

            // add roles to claims
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // set secret key
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.GetSection("JWT:SecretKey").Value));

            // define security token descritpor
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Today.AddDays(1),
                SigningCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };


            // create token
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}

