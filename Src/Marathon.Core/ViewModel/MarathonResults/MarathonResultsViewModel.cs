using System;
using System.Windows.Input;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.MarathonResults.Models;
using Marathon.Core.ViewModel.MarathonResults.ResultsList;

namespace Marathon.Core.ViewModel.MarathonResults
{
    /// <summary>
    /// The view model for a marathon results page
    /// </summary>
    public class MarathonResultsViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of spent marathons
        /// </summary>
        public IEnumerable<string> Marathons { get; set; }

        /// <summary>
        /// Selected marathon
        /// </summary>
        public string Marathon { get; set; }

        /// <summary>
        /// List of distances of marathon
        /// </summary>
        public IEnumerable<string> Distances { get; set; }

        /// <summary>
        /// Selected distance
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// List of runner gender
        /// </summary>
        public IEnumerable<string> Genders { get; set; }

        /// <summary>
        /// Selected gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// List of age categories
        /// </summary>
        public IEnumerable<string> AgeCategories { get; set; }

        /// <summary>
        /// Selected age category
        /// </summary>
        public string AgeCategory { get; set; }

        /// <summary>
        /// Count of runners which take part on marathon
        /// </summary>
        public long TotalRunnersCount { get; set; }

        /// <summary>
        /// Count of runners which complete marathon distance
        /// </summary>
        public long FinishedRunnersCount { get; set; }

        /// <summary>
        /// Average time of completion marathon distance
        /// </summary>
        public TimeSpan AverageTime { get; set; }

        /// <inheritdoc cref="MarathonResultsCondition"/>
        public MarathonResultsCondition ResultsCondition { get; set; }

        /// <inheritdoc cref="MarathonResultsListViewModel"/>
        public MarathonResultsListViewModel Results { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Find marathon results by condition of marathon properties
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// Clear marathon results condition
        /// </summary>
        public ICommand ClearCommand { get; set; }

        #endregion

        #region Constructor

        public MarathonResultsViewModel()
        {
            PageCaption = new PageCaptionViewModel("Результаты предыдущих гонок");

            Results = new MarathonResultsListViewModel();
            ResultsCondition = new MarathonResultsCondition();

            FindCommand = new RelayCommand(FindMarathonResults);
            ClearCommand = new RelayCommand(ClearMarathonResults);
        }

        #endregion

        #region Command Helpers

        private void FindMarathonResults(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearMarathonResults(object obj)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
