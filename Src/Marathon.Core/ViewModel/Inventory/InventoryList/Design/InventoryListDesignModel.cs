using System.Linq;

namespace Marathon.Core.ViewModel.Inventory.InventoryList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="InventoryListViewModel"/>
    /// </summary>
    public class InventoryListDesignModel : InventoryListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryListDesignModel Instance => new InventoryListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryListDesignModel()
        {
            SignedUpRunnersCount = 123;

            Items = Enumerable.Range(1, 10).Select(x => new InventoryListItemDesignModel());

            var items = Items as InventoryListItemViewModel[] ?? Items.ToArray();

            ItemsSummary = new InventoryListItemViewModel
            {
                Name = "Выбрало данный вариант",
                TypeA = items.Sum(x => x.TypeA),
                TypeB = items.Sum(x => x.TypeB),
                TypeC = items.Sum(x => x.TypeC),
                RequiredCount = items.Sum(x => x.RequiredCount),
                RemindCount = items.Sum(x => x.RemindCount),
            };
        }

        #endregion
    }
}
