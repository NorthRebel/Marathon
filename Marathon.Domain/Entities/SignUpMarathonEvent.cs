using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class SignUpMarathonEvent : IEntity<int>
    {
        public int Id { get; set; }
        public short? BibNumber { get; set; }
        public int? RaceTime { get; set; }
        public string EventId { get; set; }
        public int SignUpId { get; set; }

        public MarathonSignUp SignUp { get; set; }
        public Event Event { get; set; }
    }
}
