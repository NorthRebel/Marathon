﻿using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    /// <summary>
    /// Short info about <see cref="Country"/>
    /// </summary>
    public sealed class Country : IEntity
    {
        public Country()
        {
            Runners = new HashSet<Runner>();
            Volunteers = new HashSet<Volunteer>();
            Marathons = new HashSet<Marathon>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Flag { get; set; }

        public ICollection<Runner> Runners { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; }
        public ICollection<Marathon> Marathons { get; set; }
    }
}
