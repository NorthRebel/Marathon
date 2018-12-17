using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class SignUpMarathonEvent : IEntity<uint>
    {
        public uint Id { get; set; }
        public ushort? BibNumber { get; set; }
        public uint? RaceTime { get; set; }
        public string EventId { get; set; }
        public uint SignUpId { get; set; }

        public MarathonSignUp SignUp { get; set; }
        public Event Event { get; set; }
    }
}
