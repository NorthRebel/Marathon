using System;

namespace Marathon.Application.Event.Queries.GetEventsByTypes
{
    public sealed class EventLookupModel
    {
        public long Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime StartDate { get; set; }
        public short MaxParticipants { get; set; }
    }
}
