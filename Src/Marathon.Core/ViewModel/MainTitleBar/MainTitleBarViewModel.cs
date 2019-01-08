using System;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.MainTitleBar
{
    /// <summary>
    /// The view model for a main title bar control
    /// </summary>
    public class MainTitleBarViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Shows current date
        /// </summary>
        public DateTimeOffset CurrentDate { get; set; }

        /// <summary>
        /// Location of current user
        /// </summary>
        public string Location { get; set; }

        #endregion
    }
}
