using System;

namespace Marathon.Application.Users.Exceptions
{
    /// <summary>
    /// Exception that throws when can't find user type code by entered name
    /// </summary>
    public sealed class UserTypeNotExistsException : Exception
    {
        public UserTypeNotExistsException(string userTypeName) : base($"Can't find user's privileges type code by following name {userTypeName}")
        {
            
        }
    }
}
