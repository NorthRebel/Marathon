using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.InventoryReceipt.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryReceiptViewModel"/>
    /// </summary>
    public class InventoryReceiptDesignModel : InventoryReceiptViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryReceiptDesignModel Instance => new InventoryReceiptDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryReceiptDesignModel()
        {
            InventoryItemsToReceipt = new[]
            {
                new EntryViewModel<long?>("Номер бегуна"),
                new EntryViewModel<long?>("Номер бегуна"),
                new EntryViewModel<long?>("Номер бегуна"),
                new EntryViewModel<long?>("Номер бегуна"),
                new EntryViewModel<long?>("Номер бегуна"),
                new EntryViewModel<long?>("Номер бегуна"),
            };
        }

        #endregion
    }
}
