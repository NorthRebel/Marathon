namespace Marathon.Core.ViewModel.Inventory.InventoryList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryListItemViewModel"/>
    /// </summary>
    public class InventoryListItemDesignModel : InventoryListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryListItemDesignModel Instance => new InventoryListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryListItemDesignModel()
        {
            Name = "Бейсболка";
            TypeB = 123;
            TypeC = 482;
            RequiredCount = 20;
            RemindCount = (long)(TypeC + TypeB);
        }

        #endregion
    }
}
