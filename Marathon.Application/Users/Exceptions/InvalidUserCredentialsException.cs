using System;

namespace Marathon.Application.Users.Exceptions
{
    /// <summary>
    /// Exception that throws when can't authorize user by wrong credentials
    /// </summary>
    public sealed class InvalidUserCredentialsException : Exception
    {
        public InvalidUserCredentialsException() : base($"Can't authorize user because you transfer wrong credentials")
        {
            
        }
    }
}
