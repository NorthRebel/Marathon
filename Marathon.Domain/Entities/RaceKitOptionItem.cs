using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitOptionItem : IBaseEntity
    {
        public long OptionId { get; set; }
        public long ItemId { get; set; }

        public RaceKitOption Option { get; set; }
        public RaceKitItem Item { get; set; }
    }
}
