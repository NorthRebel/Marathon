using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Marathon.API.Authentication
{
    /// <summary>
    /// The authorization policy for token-based authentication
    /// </summary>
    public class AuthorizeTokenAttribute : AuthorizeAttribute
    {
        public AuthorizeTokenAttribute()
        {
            // Add the JWT bearer authentication scheme
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
