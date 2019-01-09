using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class Marathon : IEntity<byte>
    {
        public Marathon()
        {
            Events = new HashSet<Event>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string CountryId { get; set; }
        public short? YearHeld { get; set; }

        public Country Country { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
