using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Dialogs;
using Marathon.Core.ViewModel.Inventory.Dialogs.InventoryReportList;

namespace Marathon.Core.ViewModel.Inventory.Dialogs
{
    /// <summary>
    /// The view model for a inventory report dialog
    /// </summary>
    public class InventoryReportDialogViewModel : BaseDialogViewModel
    {
        #region Public Properties

        /// <inheritdoc cref="InventoryReportListViewModel"/>
        public InventoryReportListViewModel ReportItems { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Print inventory report
        /// </summary>
        public ICommand PrintCommand { get; set; }

        #endregion

        #region Constructor

        public InventoryReportDialogViewModel()
        {
            ReportItems = new InventoryReportListViewModel();

            PrintCommand = new RelayCommand(PrintInventoryReport);
        }

        #endregion

        #region Command Helpers
        
        private void PrintInventoryReport(object obj)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
