using System;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.MarathonResults.ResultsList
{

    /// <summary>
    /// The view model for marathon results list item
    /// </summary>
    public class MarathonResultsListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Runner position by completion time in marathon results 
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// Runner completion time in marathon
        /// </summary>
        public TimeSpan? CompletionTime { get; set; }

        /// <summary>
        /// Name of runner
        /// </summary>
        public string RunnerName { get; set; }

        /// <summary>
        /// Name of country
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Name of marathon
        /// NOTE: Can be null if user selects specific marathon
        /// </summary>
        public string MarathonName { get; set; }
    }
}
