using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Entities;
using System.Collections.Generic;
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
        private readonly IReadOnlyRepository<SignUpMarathonEvent> _signUpEventRepository;

        public GetEventsByTypesQueryHandler(IReadOnlyRepository<EventModel> eventRepository,
            IReadOnlyRepository<SignUpMarathonEvent> signUpEventRepository)
        {
            _eventRepository = eventRepository;
            _signUpEventRepository = signUpEventRepository;
        }

        public async Task<EventsListViewModel> Handle(GetEventsByTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<EventLookupModel> events = await GetEventsByTypeIds(request.EventTypeIds, cancellationToken);
            var enumeratedEvents = events.ToList();

            Dictionary<long, int> eventsParticipants = await GetParticipantsCountByEventIds(enumeratedEvents.Select(ev => ev.Id), cancellationToken);

            return EventsListViewModelProjection(GetEventsByTypeIds(enumeratedEvents, eventsParticipants));
        }

        #region Command handler helpers

        /// <summary>
        /// Converts <see cref="EventLookupModel"/> list to <see cref="EventsListViewModel"/>
        /// </summary>
        private EventsListViewModel EventsListViewModelProjection(IEnumerable<EventLookupModel> availableEvents)
        {
            return new EventsListViewModel
            {
                Events = availableEvents
            };
        }

        /// <summary>
        /// Get available events list by participants count selection
        /// </summary>
        /// <param name="events">Events list selected by eventTypeIds and current date</param>
        /// <param name="eventsParticipants">Key value pair where Key is event id; Value is count of participants</param>
        /// <returns>Available events list by participants count selection</returns>
        private IEnumerable<EventLookupModel> GetEventsByTypeIds(IEnumerable<EventLookupModel> events, Dictionary<long, int> eventsParticipants)
        {
            return from ev in events
                   join evPart in eventsParticipants on ev.Id equals evPart.Key
                   where (ev.MaxParticipants - evPart.Value) > 0
                   select ev;
        }

        /// <summary>
        /// Get count of signed up runners by event
        /// </summary>
        /// <returns>Key value pair where Key is event id; Value is count of participants</returns>
        private async Task<Dictionary<long, int>> GetParticipantsCountByEventIds(IEnumerable<long> eventIds, CancellationToken cancellationToken)
        {
            return await _signUpEventRepository.GetAsync(
                e => e.Where(ev => eventIds.Contains(ev.EventId))
                    .GroupBy(x => x.EventId)
                    .Select(x => new
                    {
                        Key = x.Key,
                        Value = x.Count()
                    })
                    .ToDictionary(x => x.Key, x => x.Value),
                cancellationToken);
        }

        /// <summary>
        /// Find <see cref="Domain.Entities.Event"/> list by ids and converts it to <see cref="EventLookupModel"/> list
        /// </summary>
        /// <remarks>
        /// This list not selected by available MaxParticipants property on event.
        /// </remarks>
        private async Task<IEnumerable<EventLookupModel>> GetEventsByTypeIds(IEnumerable<long> eventTypeIds, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAsync(e => e.Where(ev => eventTypeIds.Contains(ev.Id) && ev.StartDate >= DateTime.UtcNow)
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
