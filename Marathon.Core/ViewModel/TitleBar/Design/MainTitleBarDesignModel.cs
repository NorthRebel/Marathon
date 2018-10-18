using System;

namespace Marathon.Core.ViewModel.TitleBar.Design
{
    /// <summary>
    /// The design-time data for a <see cref="TitleBarViewModel"/>
    /// </summary>
    public class TitleBarDesignModel : TitleBarViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TitleBarDesignModel Instance => new TitleBarDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TitleBarDesignModel()
        {
            LogoutButtonVisible = false;
        }

        #endregion
    }
}
