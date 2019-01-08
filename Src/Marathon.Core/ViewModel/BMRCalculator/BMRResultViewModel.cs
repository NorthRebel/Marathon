using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.BMRCalculator.Models;

namespace Marathon.Core.ViewModel.BMRCalculator
{
    /// <summary>
    /// The view model for show basal metabolic rate result of calculations
    /// </summary>
    public class BMRResultViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Value of BMR calculations
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// List of daily wasted calories by activity level
        /// </summary>
        public IEnumerable<KeyValuePair<ActivityLevel, LifestyleWasteCalories>> WastedCalories { get; set; }

        #endregion
    }
}
