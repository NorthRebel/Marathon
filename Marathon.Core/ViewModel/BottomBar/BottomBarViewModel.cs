using System;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.BottomBar
{
    /// <summary>
    /// The view model for a bottom bar control
    /// </summary>
    public class BottomBarViewModel : BaseViewModel
    {
        #region Private Members

        

        #endregion

        #region Public Properties

        /// <summary>
        /// Shows current date
        /// </summary>
        public TimeSpan TimeToBegin { get; set; }

        #endregion
    }
}
