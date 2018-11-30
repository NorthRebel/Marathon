using System;
using MediatR;

namespace Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable
{
    /// <summary>
    /// Check race kit items count in stock
    /// </summary>
    public sealed class IsRaceKitOptionAvailableQuery : IRequest<bool>
    {
        public char RaceKitOptionId { get; set; }

        public IsRaceKitOptionAvailableQuery(char raceKitOptionId)
        {
            RaceKitOptionId = raceKitOptionId;
        }
    }
}
