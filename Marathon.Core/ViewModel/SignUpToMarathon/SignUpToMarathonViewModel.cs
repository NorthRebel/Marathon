using System.Windows.Input;
using Marathon.Core.Models;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// The view model for a SignUpToMarathon page
    /// </summary>
    public class SignUpToMarathonViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Types of marathon for take part them
        /// </summary>
        public IEnumerable<string> MarathonTypesToSelect { get; set; }
        public IEnumerable<string> SelectedMarathonTypes { get; set; }

        /// <summary>
        /// Types of race kit which runner can use it in marathon
        /// </summary>
        public IEnumerable<string> RaceKits { get; set; }
        public string SelectedRaceKit { get; set; }

        /// <summary>
        /// Details which means payment amount for charity organization 
        /// </summary>
        public SponsorshipDetailsViewModel SponsorshipDetails { get; set; }

        /// <summary>
        /// Indicates sum of price of selected RaceKits and MarathonType
        /// </summary>
        public PaymentSignInMarathonViewModel PaymentDetail { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Cancellation of sign up
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Confirmation of sign up
        /// </summary>
        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpToMarathonViewModel()
        {
            SignInCommand = new RelayCommand(ConfirmSignUp);
            CancelCommand = new RelayCommand(CancelSignUp);

            PageCaption = new PageCaptionViewModel("Регистрация на марафон",
                "Пожалуйста, заполните всю информацию, чтобы зарегистрироваться на Skills Marathon 2016 проводимом в Москве. Россия. " +
                "С вами свяжутся после регистрации, для уточнения оплаты и другой информации.");
        }

        #endregion

        #region Command Helpers

        private void CancelSignUp(object obj)
        {
            GoToPage(ApplicationPage.RunnerMenu);
        }

        private void ConfirmSignUp(object obj)
        {
            GoToPage(ApplicationPage.SignUpRunnerConfirm);
        }

        #endregion
    }
}
