namespace Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryReportListItemViewModel"/>
    /// </summary>
    public class InventoryReportListItemDesignModel : InventoryReportListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryReportListItemDesignModel Instance => new InventoryReportListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryReportListItemDesignModel()
        {
            Name = "RFID браслет";
            RemindCount = 60;
            RequiredCount = 110;
            ItemsCountToOrder = RequiredCount - RemindCount;
        }

        #endregion
    }
}
