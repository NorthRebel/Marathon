using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList
{
    /// <summary>
    /// The view model for list of inventory state for report
    /// </summary>
    public class InventoryReportListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of items states in stock
        /// </summary>
        public IEnumerable<InventoryReportListItemViewModel> Items { get; set; }
    }
}
