using Marathon.Core.ViewModel.Inventory.InventoryList.Design;

namespace Marathon.Core.ViewModel.Inventory.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryViewModel"/>
    /// </summary>
    public class InventoryDesignModel : InventoryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryDesignModel Instance => new InventoryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryDesignModel()
        {
            InventoryItems = new InventoryListDesignModel();
        }

        #endregion
    }
}
