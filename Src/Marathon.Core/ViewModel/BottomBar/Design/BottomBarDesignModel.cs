using System;

namespace Marathon.Core.ViewModel.BottomBar.Design
{
    /// <summary>
    /// The design-time data for a <see cref="BottomBarViewModel"/>
    /// </summary>
    public class BottomBarDesignModel : BottomBarViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static BottomBarDesignModel Instance => new BottomBarDesignModel();

        #endregion

        #region Private Members

        /// <summary>
        /// Date of beginning of the marathon
        /// </summary>
        private DateTimeOffset _beginDate;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BottomBarDesignModel()
        {
            _beginDate = new DateTimeOffset(2018, 12, 24, 3, 0, 0, TimeSpan.Zero);
            var currentDate = DateTimeOffset.UtcNow;
            
            TimeToBegin = _beginDate.Subtract(currentDate);
        }

        #endregion
    }
}
