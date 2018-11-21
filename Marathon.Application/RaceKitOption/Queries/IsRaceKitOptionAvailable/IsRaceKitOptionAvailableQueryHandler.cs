using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable
{
    /// <summary>
    /// Handles <see cref="IsRaceKitOptionAvailableQuery"/>
    /// </summary>
    public sealed class IsRaceKitOptionAvailableQueryHandler : IRequestHandler<IsRaceKitOptionAvailableQuery, bool>
    {
        private readonly IReadOnlyRepository<RaceKitItem> _raceKitItemRepository;
        private readonly IReadOnlyRepository<RaceKitOptionItem> _optionItemRepository;

        public IsRaceKitOptionAvailableQueryHandler(IReadOnlyRepository<RaceKitItem> raceKitItemRepository, 
            IReadOnlyRepository<RaceKitOptionItem> optionItemRepository)
        {
            _raceKitItemRepository = raceKitItemRepository;
            _optionItemRepository = optionItemRepository;
        }

        public async Task<bool> Handle(IsRaceKitOptionAvailableQuery request, CancellationToken cancellationToken)
        {
            return CheckRaceKitItemStockState(
                await GetItemsOfRaceKitOptionByIds(
                await FindItemsOfRaceKitOption(request.RaceKitOptionId, cancellationToken), cancellationToken));
        }

        #region Command handler helpers

        private async Task<IEnumerable<long>> FindItemsOfRaceKitOption(long raceKitOptionId, CancellationToken cancellationToken)
        {
            IEnumerable<RaceKitOptionItem> raceKitOptionItems = await _optionItemRepository.GetAsync(oi => oi.Where(o => o.OptionId == raceKitOptionId), cancellationToken);

            return raceKitOptionItems.Select(o => o.ItemId);
        }

        private async Task<IEnumerable<RaceKitItem>> GetItemsOfRaceKitOptionByIds(IEnumerable<long> itemsIds, CancellationToken cancellationToken)
        {
            return await _raceKitItemRepository.GetAsync(
                ki => ki.Where(i => itemsIds.Contains(i.Id)),
                cancellationToken);
        }

        private bool CheckRaceKitItemStockState(IEnumerable<RaceKitItem> items)
        {
            return items.All(i => i.Count > 0);
        }

        #endregion
    }
}
