using System;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.Repositories;

namespace Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption
{
    using Domain.Entities;

    /// <summary>
    /// Handles <see cref="GetCostOfSelectedRaceKitOptionQuery"/>
    /// </summary>
    public sealed class GetCostOfSelectedRaceKitOptionQueryHandler : IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal>
    {
        private readonly IReadOnlyRepository<RaceKitOption> _raceKitOptionRepository;

        public GetCostOfSelectedRaceKitOptionQueryHandler(IReadOnlyRepository<Domain.Entities.RaceKitOption> raceKitOptionRepository)
        {
            _raceKitOptionRepository = raceKitOptionRepository;
        }

        public async Task<decimal> Handle(GetCostOfSelectedRaceKitOptionQuery request, CancellationToken cancellationToken)
        {
            RaceKitOption option = await _raceKitOptionRepository.GetAsync(r => r.SingleOrDefault(x => x.Id == request.RaceKitOptionId), cancellationToken);

            if (option == null)
                // TODO: Create custom exception
                throw new NullReferenceException("Can't find race kit option by entered id");

            // TODO: Create check for items count in stock

            return option.Cost;
        }

        #region Command handler helpers



        #endregion
    }
}
