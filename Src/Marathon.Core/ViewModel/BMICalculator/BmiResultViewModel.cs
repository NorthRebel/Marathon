using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.BMICalculator.Models;

namespace Marathon.Core.ViewModel.BMICalculator
{
    /// <summary>
    /// The view model for show body mass index result of calculations
    /// </summary>
    public class BMIResultViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Value of BMI calculations
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// Image about user body state
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Description about user body state
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Segments of result scale
        /// </summary>
        public IEnumerable<ScaleSegment> Segments { get; set; }

        #endregion
    }
}
