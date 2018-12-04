using System;
using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class Event : IEntity<string>
    {
        public Event()
        {
            SignUpMarathonEvents = new HashSet<SignUpMarathonEvent>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public ushort? MaxParticipants { get; set; }
        public byte MarathonId { get; set; }
        public string EventTypeId { get; set; }

        public EventType EventType { get; set; }
        public Marathon Marathon { get; set; }
        public ICollection<SignUpMarathonEvent> SignUpMarathonEvents { get; set; }
    }
}
