using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel
{
    /// <summary>
    /// The view model for a check runner page
    /// </summary>
    public class CheckRunnerViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// Move user to <see cref="ApplicationPage.SignIn"/> page
        /// </summary>
        public ICommand ITookPartEarlierCommand { get; set; }

        /// <summary>
        /// Move user to <see cref="ApplicationPage.SignUpRunner"/> page
        /// </summary>
        public ICommand IamNewParticipantCommand { get; set; }

        #endregion

        #region Constructor

        public CheckRunnerViewModel()
        {
            ITookPartEarlierCommand = new RelayCommand(x => GoToPage(ApplicationPage.SignIn));
            IamNewParticipantCommand = new RelayCommand(x => GoToPage(ApplicationPage.SignUpRunner));
        }

        #endregion
    }
}
