using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Jwt
{
    public static class JwtManager
    {

        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(string email, int expireDays = 2)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(email));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "CodeMaze",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(expireDays),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}