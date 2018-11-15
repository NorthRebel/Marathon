using MediatR;
using System.Collections.Generic;

namespace Marathon.Application.Event.Queries.GetEventsByTypes
{
    /// <summary>
    /// Gets projected collection of <see cref="Domain.Entities.Event"/> by selected ids while runner sign's up to marathon
    /// </summary>
    public sealed class GetEventsByTypesQuery : IRequest<EventsListViewModel>
    {
        public IEnumerable<long> EventTypeIds { get; set; }

        public GetEventsByTypesQuery(IEnumerable<long> eventTypeIds)
        {
            EventTypeIds = eventTypeIds;
        }
    }
}
