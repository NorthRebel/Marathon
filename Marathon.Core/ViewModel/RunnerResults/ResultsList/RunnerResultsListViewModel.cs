using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerResults.ResultsList
{
    /// <summary>
    /// The view model for runner results list
    /// </summary>
    public class RunnerResultsListViewModel : BaseViewModel
    {
        /// <summary>
        /// Runner result in spend marathon
        /// </summary>
        public IEnumerable<RunnerResultsListItemViewModel> Items { get; set; }
    }
}
