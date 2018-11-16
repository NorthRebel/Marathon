using System;

namespace Marathon.Application.Event.Exceptions
{
    /// <summary>
    /// Exception that throws when can't find marathon events by selected event types
    /// </summary>
    public sealed class NoEventsOfSelectedTypesException : Exception
    {
        public NoEventsOfSelectedTypesException() : base("Can't find marathon events by selected event types")
        {
            
        }
    }
}
