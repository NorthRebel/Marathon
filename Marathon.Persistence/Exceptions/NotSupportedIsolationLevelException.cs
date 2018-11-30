using System;
using System.Data;

namespace Marathon.Persistence.Exceptions
{
    /// <summary>
    /// Exception that throws when current database provider doesn't support selected isolation level
    /// </summary>
    public sealed class NotSupportedIsolationLevelException : Exception
    {
        public NotSupportedIsolationLevelException(string providerName, IsolationLevel isolationLevel) 
            : base($"Current provider '{providerName}' doesn't support selected isolation level '{isolationLevel}'")
        {
        }
    }
}
