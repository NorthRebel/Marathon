using Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList.Design;

namespace Marathon.Core.ViewModel.Inventory.Dialogs.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryReportDialogViewModel"/>
    /// </summary>
    public class InventoryReportDialogDesignModel : InventoryReportDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryReportDialogDesignModel Instance => new InventoryReportDialogDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryReportDialogDesignModel()
        {
            Title = "Отчет";
            ReportItems = new InventoryReportListDesignModel();
        }

        #endregion
    }
}
