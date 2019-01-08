using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.TitleBar
{
    /// <summary>
    /// The view model for a title bar control
    /// </summary>
    public class TitleBarViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Hide logout button if user isn't sign in
        /// </summary>
        public bool LogoutButtonVisible { get; set; }

        /// <summary>
        /// Enables/disables <see cref="GoBackCommand"/>
        /// </summary>
        public bool GoBackEnabled { get; set; } = true;

        #endregion

        #region Commands

        /// <summary>
        /// Returns user to previous page
        /// </summary>
        public ICommand GoBackCommand { get; set; }

        /// <summary>
        /// Logout user from system
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        #endregion

        #region Constructor

        public TitleBarViewModel()
        {
            GoBackCommand = new RelayCommand(x => GoBack(), o => GoBackEnabled);
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Returns user to previous page
        /// </summary>
        private void GoBack()
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        #endregion
    }
}
