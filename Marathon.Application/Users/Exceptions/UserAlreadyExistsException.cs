using System;

namespace Marathon.Application.Users.Exceptions
{
    /// <summary>
    /// Exception that throws if user (by email) already exists 
    /// </summary>
    public sealed class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email) : base($"User with email \"{email}\" already exists!")
        {
        }
    }
}
