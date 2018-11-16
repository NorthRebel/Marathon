﻿using System;

namespace Marathon.Application.Exceptions
{
    /// <summary>
    /// Exception that throws when can't find race kit option by entered id
    /// </summary>
    public sealed class RaceKitOptionNotExistsException : Exception
    {
        public RaceKitOptionNotExistsException(long raceKitOptionId) : base($"Can't find race kit option by following id {raceKitOptionId}")
        {
            
        }
    }
}
