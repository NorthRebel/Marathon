using System.Linq;

namespace Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryReportListViewModel"/>
    /// </summary>
    public class InventoryReportListDesignModel : InventoryReportListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryReportListDesignModel Instance => new InventoryReportListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryReportListDesignModel()
        {
            Items = Enumerable.Range(1, 10).Select(x => new InventoryReportListItemDesignModel());
        }

        #endregion
    }
}
