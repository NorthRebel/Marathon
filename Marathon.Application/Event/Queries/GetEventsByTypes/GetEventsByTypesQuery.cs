using MediatR;
using System.Collections.Generic;

namespace Marathon.Application.Event.Queries.GetEventsByTypes
{
    /// <summary>
    /// Gets projected collection of <see cref="Domain.Entities.Event"/> by selected ids while runner sign's up to marathon
    /// </summary>
    public sealed class GetEventsByTypesQuery : IRequest<EventsListViewModel>
    {
        public IEnumerable<string> EventTypeIds { get; set; }

        public GetEventsByTypesQuery(IEnumerable<string> eventTypeIds)
        {
            EventTypeIds = eventTypeIds;
        }
    }
}
