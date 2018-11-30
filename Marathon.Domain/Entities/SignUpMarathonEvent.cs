using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class SignUpMarathonEvent : IEntity
    {
        public long Id { get; set; }
        public short? BibNumber { get; set; }
        public long? RaceTime { get; set; }
        public string EventId { get; set; }
        public long SignUpId { get; set; }

        public MarathonSignUp SignUp { get; set; }
        public Event Event { get; set; }
    }
}
