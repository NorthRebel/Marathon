using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.HowLongMarathon.ItemsList.Items;

namespace Marathon.Core.ViewModel.HowLongMarathon.ItemsList
{
    /// <summary>
    /// The view model for a how long marathon items list
    /// </summary>
    public class HowLongMarathonItemsListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Caption of list
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Items of specific how long comparison category
        /// </summary>
        public IEnumerable<HowLongMarathonItemViewModel> Items { get; set; }

        #endregion
    }
}
