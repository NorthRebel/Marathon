using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitItem : IEntity
    {
        public RaceKitItem()
        {
            OptionItems = new HashSet<OptionItem>();
            RaceKitOptions = new HashSet<RaceKitOption>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }


        public ICollection<OptionItem> OptionItems { get; set; }
        public ICollection<RaceKitOption> RaceKitOptions { get; set; }
    }
}
