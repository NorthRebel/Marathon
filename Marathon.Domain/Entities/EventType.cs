using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class EventType : IEntity
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
