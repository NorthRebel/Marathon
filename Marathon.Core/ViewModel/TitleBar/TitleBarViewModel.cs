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
    }
}
