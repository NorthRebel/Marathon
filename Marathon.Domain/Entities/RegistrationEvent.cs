using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RegistrationEvent : IEntity
    {
        public long Id { get; set; }
        public short BibNumber { get; set; }
        public long RaceTime { get; set; }
        public long EventId { get; set; }
        public long RegistrationId { get; set; }

        public Registration Registration { get; set; }
        public Event Event { get; set; }
    }
}
