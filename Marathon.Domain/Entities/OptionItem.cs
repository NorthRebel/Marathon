namespace Marathon.Domain.Entities
{
    public sealed class OptionItem
    {
        public long RaceKitOptionId { get; set; }
        public long RaceKitItemId { get; set; }

        public RaceKitOption RaceKitOption { get; set; }
        public RaceKitItem RaceKitItem { get; set; }
    }
}
