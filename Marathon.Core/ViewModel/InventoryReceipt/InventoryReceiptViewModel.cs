using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.InventoryReceipt
{
    /// <summary>
    /// The view model for a inventory receipt page
    /// </summary>
    public class InventoryReceiptViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Items to receipt
        /// </summary>
        public IEnumerable<EntryViewModel<long?>> InventoryItemsToReceipt { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Registration of receipt of inventory at the warehouse
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        public InventoryReceiptViewModel()
        {
            PageCaption = new PageCaptionViewModel("Поступление инвентаря");

            SaveCommand = new RelayCommand(RegisterInventoryReceipt);
        }

        #endregion

        #region Command Helpers

        private void RegisterInventoryReceipt(object obj)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
