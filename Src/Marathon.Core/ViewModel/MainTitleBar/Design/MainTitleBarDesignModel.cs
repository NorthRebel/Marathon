using System;

namespace Marathon.Core.ViewModel.MainTitleBar.Design
{
    /// <summary>
    /// The design-time data for a <see cref="MainTitleBarViewModel"/>
    /// </summary>
    public class MainTitleBarDesignModel : MainTitleBarViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MainTitleBarDesignModel Instance => new MainTitleBarDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainTitleBarDesignModel()
        {
            CurrentDate = DateTimeOffset.UtcNow;
            Location = "Москва, Россия";
        }

        #endregion
    }
}
