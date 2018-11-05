using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Inventory.Dialogs.Design;
using Marathon.Core.ViewModel.Inventory.InventoryList;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Inventory
{
    /// <summary>
    /// The view model for a inventory page
    /// </summary>
    public class InventoryViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <inheritdoc cref="InventoryListViewModel"/>
        public InventoryListViewModel InventoryItems { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Goes to print-preview dialog which shows count of items to order
        /// </summary>
        public ICommand ReportCommand { get; set; }

        /// <summary>
        /// Goes to page which user can replenish inventory items
        /// </summary>
        public ICommand ReceiptCommand { get; set; }

        #endregion

        #region Constructor

        public InventoryViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Инвентарь"
            };

            InventoryItems = new InventoryListViewModel();

            ReportCommand = new RelayCommand(ShowPrintPreviewReport);
            ReceiptCommand = new RelayCommand(x => GoToPage(ApplicationPage.InventoryReceipt));
        }


        #endregion

        #region Command Helpers

        private async void ShowPrintPreviewReport(object obj)
        {
            // TODO: Replace dummy data
            await IoC.IoC.UI.ShowInventoryReport(new InventoryReportDialogDesignModel());
        }
        

        #endregion
    }
}
