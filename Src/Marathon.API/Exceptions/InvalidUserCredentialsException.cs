using System;

namespace Marathon.API.Exceptions
{
    /// <summary>
    /// Exception that throws when can't authorize user by wrong credentials
    /// </summary>
    internal class InvalidUserCredentialsException : Exception
    {
        public InvalidUserCredentialsException() : base("Can't authorize user because you transfer wrong credentials")
        {
        }
    }
}
