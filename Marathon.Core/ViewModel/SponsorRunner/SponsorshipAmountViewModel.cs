using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SponsorRunner
{
    /// <summary>
    /// The view model for a sponsorship amount part of SponsorRunner page
    /// </summary>
    public class SponsorshipAmountViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Amount of sponsorship
        /// </summary>
        public decimal Ammount { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Increases amount value
        /// </summary>
        public ICommand IncreaseAmountCommand { get; set; }

        /// <summary>
        /// Decrease amount value
        /// </summary>
        public ICommand DecreaseAmountCommand { get; set; }

        /// <summary>
        /// Confirmation of sponsorship
        /// </summary>
        public ICommand ConfirmCommand { get; set; }

        /// <summary>
        /// Cancellation of sponsorship
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public SponsorshipAmountViewModel()
        {
            ConfirmCommand = new RelayCommand(ConfirmSponsorship);
            CancelCommand = new RelayCommand(CancelSponsorship);
        }

        #endregion

        #region Command Helpers
        
        private void CancelSponsorship(object obj)
        {
            GoToPage(ApplicationPage.Main, true);
        }

        private void ConfirmSponsorship(object obj)
        {
            GoToPage(ApplicationPage.SponsorshipConfirm);
        }

        #endregion
    }
}
