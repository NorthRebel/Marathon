using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SponsorsReview.CharityList
{
    /// <summary>
    /// The view model for charity list which get amount form sponsors
    /// </summary>
    public class CharityListViewModel : BaseViewModel
    {
        /// <summary>
        /// Charity organization that receive amount form sponsors
        /// </summary>
        public IEnumerable<CharityListItemViewModel> Items { get; set; }

        /// <summary>
        /// Count of <see cref="Items"/>
        /// </summary>
        public long ItemsCount { get; set; }

        /// <summary>
        /// Total sum of received amount
        /// </summary>
        public decimal TotalSummary { get; set; }
    }
}
