using System;
using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Details of the <see cref="Runner"/>
    /// </summary>
    public sealed class Runner : IEntity
    {
        public Runner()
        {
            Registrations = new HashSet<Registration>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long CountryId { get; set; }
        public byte[] Photo { get; set; }

        public User User { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
