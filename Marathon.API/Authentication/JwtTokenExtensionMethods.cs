using System;
using System.Text;
using Marathon.API.Settings;
using System.Security.Claims;
using Marathon.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Marathon.API.Authentication
{
    /// <summary>
    /// Extension methods for working with Jwt bearer tokens
    /// </summary>
    public static class JwtTokenExtensionMethods
    {
        /// <summary>
        /// Generates a Jwt bearer token containing the users username
        /// </summary>
        /// <param name="user">The users details</param>
        /// <returns></returns>
        public static string GenerateJwtToken(this User user)
        {
            // Set our tokens claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),

                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserTypeId.ToString())
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                // Get the secret key from configuration
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsProvider.Jwt.SecretKey)),
                // Use HS256 algorithm
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                issuer: AppSettingsProvider.Jwt.Issuer,
                audience: AppSettingsProvider.Jwt.Audience,
                claims: claims,
                signingCredentials: credentials,
                // Expire if not used for 3 months
                expires: DateTime.Now.AddMonths(3)
            );

            // Return the generated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
