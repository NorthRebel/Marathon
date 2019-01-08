using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Inventory.InventoryList
{
    /// <summary>
    /// The view model for list item of inventory state
    /// TODO: Make types of kit creation dynamically!!! 
    /// </summary>
    public class InventoryListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of item which contains in kit
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Stock items count of race kit type A
        /// </summary>
        public long? TypeA { get; set; }

        /// <summary>
        /// Stock items count of race kit type B
        /// </summary>
        public long? TypeB { get; set; }

        /// <summary>
        /// Stock items count of race kit type C
        /// </summary>
        public long? TypeC { get; set; }

        /// <summary>
        /// Count of required items for each race kit which runners will buy
        /// </summary>
        public long RequiredCount { get; set; }

        /// <summary>
        /// Count of remind items in stock
        /// </summary>
        public long RemindCount { get; set; }
    }
}
