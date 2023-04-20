using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Jwt
{
    public static class JwtManager
    {

        public const string Secret = "2Fr4ZEhhyZWsLmQFv0YKv46592JnuVF6yD3jW87KD8E=SWNZoOujac0m6iZLucGpW8xII5KvHGmOR9MhYfE8DKc=";

        public static string GenerateToken(string email, int expireDays = 2)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "CodeMaze",
                audience: "https://localhost:5001",
                claims: new List<Claim>() {
                    new Claim(ClaimTypes.Email, email)
                 },
                expires: DateTime.Now.AddDays(expireDays),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}