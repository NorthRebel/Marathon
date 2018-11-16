using System;

namespace Marathon.Application.Exceptions
{
    /// <summary>
    /// Exception that throws when not all items in stock of selected race kit item
    /// </summary>
    public sealed class NotAllItemsInStockOfRaceKitOption : Exception
    {
        public NotAllItemsInStockOfRaceKitOption(long raceKitOptionId) : base("You can't select this race kit option because not all items in stock")
        {
            
        }
    }
}
