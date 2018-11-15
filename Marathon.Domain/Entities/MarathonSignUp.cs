using System;
using Marathon.Domain.Common;
using System.Collections.Generic;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="MarathonSignUp"/>
    /// </summary>
    public sealed class MarathonSignUp : IEntity
    {
        public MarathonSignUp()
        {
            Sponsorships = new HashSet<Sponsorship>();
            SignUpMarathonEvents = new HashSet<SignUpMarathonEvent>();
        }

        public long Id { get; set; }
        public DateTime SignUpDate { get; set; }
        public decimal Cost { get; set; }
        public decimal SponsorshipTarget { get; set; }
        public long RunnerId { get; set; }
        public long CharityId { get; set; }
        public long RaceKitOptionId { get; set; }
        public long SignUpStatusId { get; set; }

        public Runner Runner { get; set; }
        public Charity Charity { get; set; }
        public SignUpStatus SignUpStatus { get; set; }
        public ICollection<Sponsorship> Sponsorships { get; set; }
        public ICollection<SignUpMarathonEvent> SignUpMarathonEvents { get; set; }
    }
}
