using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList
{
    /// <summary>
    /// The view model for list item of inventory state for report
    /// </summary>
    public class InventoryReportListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of item which contains in kit
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Count of remind items in stock
        /// </summary>
        public long RemindCount { get; set; }

        /// <summary>
        /// Count of required items for each race kit which runners will buy
        /// </summary>
        public long RequiredCount { get; set; }

        /// <summary>
        /// Count of items to order which is the difference between <see cref="RequiredCount"/> and <see cref="RemindCount"/>
        /// </summary>
        public long ItemsCountToOrder { get; set; }
    }
}
