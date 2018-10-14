using System;
using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Registration"/>
    /// </summary>
    public sealed class Registration : IEntity
    {
        public Registration()
        {
            Sponsorships = new HashSet<Sponsorship>();
            RegistrationEvents = new HashSet<RegistrationEvent>();
        }

        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal Cost { get; set; }
        public decimal SponsorshipTarget { get; set; }
        public long RunnerId { get; set; }
        public long CharityId { get; set; }
        public long RaceKitOptionId { get; set; }
        public long RegistrationStatusId { get; set; }

        public Runner Runner { get; set; }
        public Charity Charity { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public ICollection<Sponsorship> Sponsorships { get; set; }
        public ICollection<RegistrationEvent> RegistrationEvents { get; set; }
    }
}
