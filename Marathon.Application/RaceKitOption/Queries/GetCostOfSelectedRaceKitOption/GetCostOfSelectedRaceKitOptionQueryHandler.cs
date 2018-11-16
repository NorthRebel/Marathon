using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Application.RaceKitOption.Exceptions;

namespace Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption
{
    using Repositories;
    using Domain.Entities;
    using IsRaceKitOptionAvailable;

    /// <summary>
    /// Handles <see cref="GetCostOfSelectedRaceKitOptionQuery"/>
    /// </summary>
    public sealed class GetCostOfSelectedRaceKitOptionQueryHandler : IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal>
    {
        private readonly IReadOnlyRepository<RaceKitOption> _raceKitOptionRepository;
        private readonly IRequestHandler<IsRaceKitOptionAvailableQuery, bool> _itemsStockChecker;

        public GetCostOfSelectedRaceKitOptionQueryHandler(IReadOnlyRepository<RaceKitOption> raceKitOptionRepository,
            IRequestHandler<IsRaceKitOptionAvailableQuery, bool> itemsStockChecker)
        {
            _raceKitOptionRepository = raceKitOptionRepository;
            _itemsStockChecker = itemsStockChecker;
        }

        public async Task<decimal> Handle(GetCostOfSelectedRaceKitOptionQuery request, CancellationToken cancellationToken)
        {
            RaceKitOption option = await GetRaceKitOptionById(request.RaceKitOptionId, cancellationToken);

            if (option == null)
                throw new RaceKitOptionNotExistsException(request.RaceKitOptionId);

            if (await CheckRaceKitItemStockState(option.Id, cancellationToken))
                throw new NotAllItemsInStockOfRaceKitOption(request.RaceKitOptionId);

            return option.Cost;
        }

        #region Command handler helpers

        private async Task<RaceKitOption> GetRaceKitOptionById(long raceKitOptionId, CancellationToken cancellationToken)
        {
            return await _raceKitOptionRepository.GetAsync(r => r.SingleOrDefault(x => x.Id == raceKitOptionId), cancellationToken);
        }

        private async Task<bool> CheckRaceKitItemStockState(long raceKitOptionId, CancellationToken cancellationToken)
        {
            return await _itemsStockChecker.Handle(new IsRaceKitOptionAvailableQuery(raceKitOptionId), cancellationToken);
        }

        #endregion
    }
}
