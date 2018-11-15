using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Marathon.Application.Repositories;
using EventModel = Marathon.Domain.Entities.Event;

namespace Marathon.Application.Event.Queries.GetEventsByTypes
{
    /// <summary>
    /// Handles <see cref="GetEventsByTypesQuery"/>
    /// </summary>
    public sealed class GetEventsByTypesQueryHandler : IRequestHandler<GetEventsByTypesQuery, EventsListViewModel>
    {
        private readonly IReadOnlyRepository<EventModel> _eventRepository;

        public GetEventsByTypesQueryHandler(IReadOnlyRepository<EventModel> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventsListViewModel> Handle(GetEventsByTypesQuery request, CancellationToken cancellationToken)
        {
            var vm = new EventsListViewModel
            {
                Events = await GetEventsByTypeIds(request.EventTypeIds, cancellationToken)
            };

            return vm;
        }

        #region Command handler helpers

        /// <summary>
        /// Find <see cref="Domain.Entities.Event"/> list by ids and converts it to <see cref="EventLookupModel"/> list
        /// </summary>
        private async Task<IEnumerable<EventLookupModel>> GetEventsByTypeIds(IEnumerable<long> eventTypeIds, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAsync(e => e.Where(ev => eventTypeIds.Contains(ev.Id))
                .Select(vm => new EventLookupModel
                {
                    Id = vm.Id,
                    StartDate = vm.StartDate,
                    Cost = vm.Cost,
                    MaxParticipants = vm.MaxParticipants
                }),
                cancellationToken);
        }

        #endregion
    }
}
