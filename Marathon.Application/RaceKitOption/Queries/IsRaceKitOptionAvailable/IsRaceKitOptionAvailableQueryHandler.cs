using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.DAL.UnitOfWork;
using Marathon.Domain.Entities;
using Marathon.DAL.Repositories;
using System.Collections.Generic;

namespace Marathon.Application.RaceKitOption.Queries.IsRaceKitOptionAvailable
{
    /// <summary>
    /// Handles <see cref="IsRaceKitOptionAvailableQuery"/>
    /// </summary>
    public sealed class IsRaceKitOptionAvailableQueryHandler : IRequestHandler<IsRaceKitOptionAvailableQuery, bool>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public IsRaceKitOptionAvailableQueryHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<bool> Handle(IsRaceKitOptionAvailableQuery request, CancellationToken cancellationToken)
        {
            return CheckRaceKitItemStockState(
                await GetItemsOfRaceKitOptionByIds(
                await FindItemsOfRaceKitOption(request.RaceKitOptionId, cancellationToken), cancellationToken));
        }

        #region Command handler helpers

        private Task<IEnumerable<short>> FindItemsOfRaceKitOption(char raceKitOptionId, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
                return context.RaceKitOptionItems.GetAsync<IEnumerable<short>>(
                    oi => oi.Where(o => o.OptionId == raceKitOptionId).Select(o => o.ItemId), cancellationToken);
        }

        private Task<IEnumerable<RaceKitItem>> GetItemsOfRaceKitOptionByIds(IEnumerable<short> itemsIds, CancellationToken cancellationToken)
        {
            using (IUnitOfWork context = _uowFactory.Create())
                return context.RaceKitItems.FindByAsync(ki => itemsIds.Contains(ki.Id), cancellationToken);
        }

        private bool CheckRaceKitItemStockState(IEnumerable<RaceKitItem> items)
        {
            return items.All(i => i.Count > 0);
        }

        #endregion
    }
}
