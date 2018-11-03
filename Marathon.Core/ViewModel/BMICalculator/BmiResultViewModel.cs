using Marathon.Core.ViewModel.Base;

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

        #endregion
    }
}
