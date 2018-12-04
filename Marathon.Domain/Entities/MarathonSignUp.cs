﻿using System;
using Marathon.Domain.Common;
using System.Collections.Generic;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="MarathonSignUp"/>
    /// </summary>
    public sealed class MarathonSignUp : IEntity<uint>
    {
        public MarathonSignUp()
        {
            Sponsorships = new HashSet<Sponsorship>();
            SignUpMarathonEvents = new HashSet<SignUpMarathonEvent>();
        }

        public uint Id { get; set; }
        public DateTime SignUpDate { get; set; }
        public decimal Cost { get; set; }
        public decimal SponsorshipTarget { get; set; }
        public uint RunnerId { get; set; }
        public uint CharityId { get; set; }
        public char RaceKitOptionId { get; set; }
        public byte SignUpStatusId { get; set; }

        public Runner Runner { get; set; }
        public Charity Charity { get; set; }
        public SignUpStatus SignUpStatus { get; set; }
        public RaceKitOption RaceKitOption { get; set; }
        public ICollection<Sponsorship> Sponsorships { get; set; }
        public ICollection<SignUpMarathonEvent> SignUpMarathonEvents { get; set; }
    }
}
