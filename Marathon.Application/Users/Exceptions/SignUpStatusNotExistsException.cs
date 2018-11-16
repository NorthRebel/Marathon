using System;

namespace Marathon.Application.Users.Exceptions
{
    /// <summary>
    /// Exception that throws when can't find sign up status code by entered name
    /// </summary>
    public sealed class SignUpStatusNotExistsException : Exception
    {
        public SignUpStatusNotExistsException(string statusName) : base($"Can't find runner's marathon sign up status code by following name {statusName}")
        {
            
        }
    }
}
