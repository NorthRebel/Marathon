using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class EventType : IEntity<string>
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
