using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.RunnerResults.ResultsList;

namespace Marathon.Core.ViewModel.RunnerResults
{
    /// <summary>
    /// The view model for runner results page
    /// </summary>
    public class RunnerResultsViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gender of current runner
        /// </summary>
        public EntryViewModel<string> Gender { get; set; }

        /// <inheritdoc cref="RunnerResultsListViewModel"/>
        public RunnerResultsListViewModel Results { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Moves user to marathon results page to show all previous results
        /// </summary>
        public ICommand ShowAllResultsCommand { get; set; }

        #endregion


        #region Constructor

        public RunnerResultsViewModel()
        {
            PageCaption = new PageCaptionViewModel("Мои результаты",
                "Это - список всех ваших прошлых результатов гонки для Marathon Skills. " +
                "Общее место сравнивает всех бегунов. " +
                "Место по категории сравнивает бегунов с одинаковым полом и возрастной категорией.");

            Gender = new EntryViewModel<string>("Пол");

            // TODO: Fix signed in button in marathon results page
            ShowAllResultsCommand = new RelayCommand(x => GoToPage(ApplicationPage.MarathonResults));
        }
        
        #endregion
    }
}
