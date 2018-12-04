using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitItem : IEntity<ushort>
    {
        public RaceKitItem()
        {
            OptionItems = new HashSet<RaceKitOptionItem>();
        }

        public ushort Id { get; set; }
        public string Name { get; set; }
        public uint Count { get; set; }


        public ICollection<RaceKitOptionItem> OptionItems { get; set; }
    }
}
