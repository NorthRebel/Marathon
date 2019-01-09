using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Inventory.InventoryList
{
    /// <summary>
    /// The view model for list of inventory state
    /// </summary>
    public class InventoryListViewModel : BaseViewModel
    {
        /// <summary>
        /// Count of runners signed up to current marathon
        /// </summary>
        public long SignedUpRunnersCount { get; set; }

        /// <summary>
        /// Summary information about each of <see cref="Items"/>
        /// </summary>
        public InventoryListItemViewModel ItemsSummary { get; set; }

        /// <summary>
        /// State of race kit item by for each kit
        /// </summary>
        public IEnumerable<InventoryListItemViewModel> Items { get; set; }
    }
}
