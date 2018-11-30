using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitItem : IEntity<short>
    {
        public RaceKitItem()
        {
            OptionItems = new HashSet<RaceKitOptionItem>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }


        public ICollection<RaceKitOptionItem> OptionItems { get; set; }
    }
}
