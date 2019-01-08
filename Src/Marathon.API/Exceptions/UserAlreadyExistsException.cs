using System;

namespace Marathon.API.Exceptions
{
    /// <summary>
    /// Exception that throws when user with same email is already exists
    /// </summary>
    internal class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("User with same email is already exists")
        {
        }
    }
}
