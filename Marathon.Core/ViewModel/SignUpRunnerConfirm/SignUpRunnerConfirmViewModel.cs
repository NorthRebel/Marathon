using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.SignUpRunnerConfirm
{
    /// <summary>
    /// The view model for a Sign up runner confirm page
    /// </summary>
    public class SignUpRunnerConfirmViewModel : SignedInViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the view model
        /// </summary>
        public static SignUpRunnerConfirmViewModel Instance => new SignUpRunnerConfirmViewModel();

        #endregion

        #region Commands

        /// <summary>
        /// Returns runner to menu page
        /// </summary>
        public ICommand OkCommand { get; set; }

        #endregion

        #region Constructor

        public SignUpRunnerConfirmViewModel()
        {
            OkCommand = new RelayCommand(x => GoBack());

            PageCaption = new PageCaptionViewModel("Спасибо за вашу регистрацию в качестве бегуна!",
                "Спасибо за вашу регистрацию в качестве бегуна в Marathon Skills 2016!\n" +
                "С вами свяжутся по поводу оплаты.");
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Returns runner to menu page
        /// </summary>
        private void GoBack()
        {
            GoToPage(ApplicationPage.RunnerMenu);
        }

        #endregion
    }
}
