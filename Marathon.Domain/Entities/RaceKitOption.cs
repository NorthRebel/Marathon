using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitOption : IEntity
    {
        public RaceKitOption()
        {
            OptionItems = new HashSet<OptionItem>();
            SignUps = new HashSet<MarathonSignUp>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<OptionItem> OptionItems { get; set; }
        public ICollection<MarathonSignUp> SignUps { get; set; }
    }
}
