using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitOption : IEntity
    {
        public RaceKitOption()
        {
            OptionItems = new HashSet<OptionItem>();
            Registrations = new HashSet<Registration>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<OptionItem> OptionItems { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
