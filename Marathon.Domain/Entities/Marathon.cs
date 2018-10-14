using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class Marathon : IEntity
    {
        public Marathon()
        {
            Events = new HashSet<Event>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public short? YearHeld { get; set; }

        public Country Country { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
