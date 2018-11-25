using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
using Marathon.Application.RaceKitOption.Exceptions;

namespace Marathon.Application.RaceKitOption.Queries.GetCostOfSelectedRaceKitOption
{
    using Domain.Entities;
    using IsRaceKitOptionAvailable;

    /// <summary>
    /// Handles <see cref="GetCostOfSelectedRaceKitOptionQuery"/>
    /// </summary>
    public sealed class GetCostOfSelectedRaceKitOptionQueryHandler : IRequestHandler<GetCostOfSelectedRaceKitOptionQuery, decimal>
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IRequestHandler<IsRaceKitOptionAvailableQuery, bool> _itemsStockChecker;

        public GetCostOfSelectedRaceKitOptionQueryHandler(IUnitOfWorkFactory uowFactory,
            IRequestHandler<IsRaceKitOptionAvailableQuery, bool> itemsStockChecker)
        {
            _uowFactory = uowFactory;
            _itemsStockChecker = itemsStockChecker;
        }

        public async Task<decimal> Handle(GetCostOfSelectedRaceKitOptionQuery request, CancellationToken cancellationToken)
        {
            RaceKitOption option = await GetRaceKitOptionById(request.RaceKitOptionId, cancellationToken);

            if (option == null)
                throw new RaceKitOptionNotExistsException(request.RaceKitOptionId);

            if (!await CheckRaceKitItemStockState(option.Id, cancellationToken))
                throw new NotAllItemsInStockOfRaceKitOptionException(request.RaceKitOptionId);

            return option.Cost;
        }

        #region Command handler helpers

        private Task<RaceKitOption> GetRaceKitOptionById(long raceKitOptionId, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
                return context.RaceKitOptions.GetSingleAsync(r => r.Id == raceKitOptionId, cancellationToken);
        }

        private async Task<bool> CheckRaceKitItemStockState(long raceKitOptionId, CancellationToken cancellationToken)
        {
            return await _itemsStockChecker.Handle(new IsRaceKitOptionAvailableQuery(raceKitOptionId), cancellationToken);
        }

        #endregion
    }
}
