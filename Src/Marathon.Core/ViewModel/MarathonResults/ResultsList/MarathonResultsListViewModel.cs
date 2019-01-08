using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.MarathonResults.ResultsList
{
    /// <summary>
    /// The view model for marathon results list
    /// </summary>
    public class MarathonResultsListViewModel : BaseViewModel
    {
        /// <summary>
        /// Runner result in spend marathon
        /// </summary>
        public IEnumerable<MarathonResultsListItemViewModel> Items { get; set; }
    }
}
