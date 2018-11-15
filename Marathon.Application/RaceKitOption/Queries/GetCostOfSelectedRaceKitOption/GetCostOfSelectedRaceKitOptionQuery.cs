using MediatR;

namespace Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption
{
    /// <summary>
    /// Gets cost of selected race kit option when runner signs up to marathon
    /// </summary>
    public sealed class GetCostOfSelectedRaceKitOptionQuery : IRequest<decimal>
    {
        public long RaceKitOptionId { get; set; }

        public GetCostOfSelectedRaceKitOptionQuery(long raceKitOptionId)
        {
            RaceKitOptionId = raceKitOptionId;
        }
    }
}
