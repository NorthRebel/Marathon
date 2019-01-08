using System;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerResults.ResultsList
{
    /// <summary>
    /// The view model for runner results list item
    /// </summary>
    public class RunnerResultsListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of marathon
        /// NOTE: Can be null if user selects specific marathon
        /// </summary>
        public string MarathonName { get; set; }

        /// <summary>
        /// Name of marathon's distance
        /// </summary>
        public string DistanceName { get; set; }

        /// <summary>
        /// Runner completion time in marathon
        /// </summary>
        public TimeSpan? CompletionTime { get; set; }
        
        /// <summary>
        /// Runner position by completion time in marathon results 
        /// </summary>
        public long CommonPosition { get; set; }

        /// <summary>
        /// Runner's age category for get specific inner results in marathon
        /// </summary>
        public string AgeCategory { get; set; }

        /// <summary>
        /// Runner position by completion time in marathon results of specific age category
        /// </summary>
        public long PositionInCategory { get; set; }
    }
}
