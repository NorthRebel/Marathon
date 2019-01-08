using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SponsorshipConfirm
{
    /// <summary>
    /// The view model for a Sponsorship confirm page
    /// </summary>
    public class SponsorshipConfirmViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Sponsored runner
        /// </summary>
        public string RunnerName { get; set; }

        /// <summary>
        /// Charity name of selected runner
        /// </summary>
        public string RunnerCharityName { get; set; }

        /// <summary>
        /// Amount of sponsorship
        /// </summary>
        public decimal Amount { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Returns user to previous page
        /// </summary>
        public ICommand GoBackCommand { get; set; }

        #endregion

        #region Constructor

        public SponsorshipConfirmViewModel()
        {
            GoBackCommand = new RelayCommand(x => GoBack());

            PageCaption = new PageCaptionViewModel("Спасибо за вашу спонсорскую поддержку!",
                "Спасибо за поддержку бегуна в Marathon Skills 2016! " +
                "Ваше пожертвование пойдет в его благотворительную организацию.");
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Returns user to previous page
        /// </summary>
        private void GoBack()
        {
            GoToPage(ApplicationPage.Main);
        }

        #endregion
    }
}
