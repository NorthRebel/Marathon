using System.Collections.Generic;

namespace Marathon.Application.Event.Queries.GetEventsByTypes
{
    public sealed class EventsListViewModel
    {
        public IEnumerable<EventLookupModel> Events { get; set; }
    }
}
