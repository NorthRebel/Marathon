using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.Menus
{
    /// <summary>
    /// The view model for a main page
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties



        #endregion

        #region Commands

        /// <summary>
        /// Move user to <see cref="ApplicationPage.CheckRunner"/> page
        /// </summary>
        public ICommand WantToBecomeRunnerCommand { get; set; }

        /// <summary>
        /// Move user to <see cref="ApplicationPage.SponsorRunner"/> page
        /// </summary>
        public ICommand WantToBecomeRunnerSponsorCommand { get; set; }

        /// <summary>
        /// Move user to <see cref="ApplicationPage.MarathonMenu"/> page
        /// </summary>
        public ICommand WantToKnowMoreAboutTheEventCommand { get; set; }

        /// <summary>
        /// Move user to <see cref="ApplicationPage.SignIn"/> page
        /// </summary>
        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            WantToBecomeRunnerCommand = new RelayCommand(x => GoToPage(ApplicationPage.CheckRunner));
            WantToBecomeRunnerSponsorCommand = new RelayCommand(x => GoToPage(ApplicationPage.SponsorRunner));
            WantToKnowMoreAboutTheEventCommand = new RelayCommand(x => GoToPage(ApplicationPage.MarathonMenu));
            SignInCommand = new RelayCommand(x => GoToPage(ApplicationPage.SignIn));
        }

        #endregion
    }
}