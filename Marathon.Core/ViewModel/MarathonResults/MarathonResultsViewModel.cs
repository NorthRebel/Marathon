using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
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
        public ItemsEntryViewModel<string> Marathons { get; set; }

        /// <summary>
        /// List of distances of marathon
        /// </summary>
        public ItemsEntryViewModel<string> Distances { get; set; }

        /// <summary>
        /// List of runner gender
        /// </summary>
        public ItemsEntryViewModel<string> Genders { get; set; }

        /// <summary>
        /// List of age categories
        /// </summary>
        public ItemsEntryViewModel<string> AgeCategories { get; set; }

        /// <summary>
        /// Count of runners which take part on marathon
        /// </summary>
        public EntryViewModel<long> TotalRunnersCount { get; set; }

        /// <summary>
        /// Count of runners which complete marathon distance
        /// </summary>
        public EntryViewModel<long> FinishedRunnersCount { get; set; }

        /// <summary>
        /// Average time of completion marathon distance
        /// </summary>
        public EntryViewModel<TimeSpan> AverageTime { get; set; }

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

            Marathons = new ItemsEntryViewModel<string>("Марафон");
            Distances = new ItemsEntryViewModel<string>("Дистанция");
            Genders = new ItemsEntryViewModel<string>("Пол");
            AgeCategories = new ItemsEntryViewModel<string>("Категория");

            TotalRunnersCount = new EntryViewModel<long>("Всего бегунов");
            FinishedRunnersCount = new EntryViewModel<long>("Всего бегунов финишировало");
            AverageTime = new EntryViewModel<TimeSpan>("Среднее время");

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
