using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public sealed class RaceKitOptionItem : IBaseEntity
    {
        public char OptionId { get; set; }
        public short ItemId { get; set; }

        public RaceKitOption Option { get; set; }
        public RaceKitItem Item { get; set; }
    }
}
