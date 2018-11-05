using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.BMRCalculator.Models
{
    /// <summary>
    /// Shows daily count of wasted calories by lifestyle
    /// </summary>
    public class LifestyleWasteCalories : EntryViewModel<double>
    {
        #region Private Members

        /// <summary>
        /// Coefficient for calculate calories by BMR
        /// </summary>
        private readonly double _calculateCoefficient;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// The background color of the entry in ARGB value
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Calculate wasted calories with coefficient
        /// </summary>
        public override double Value { get => base.Value; set => base.Value = value * _calculateCoefficient; }

        #endregion

        #region Constructor
        
        public LifestyleWasteCalories(string lifestyle, double calculateCoefficient, string background) : base(lifestyle)
        {
            _calculateCoefficient = calculateCoefficient;
            Background = background;
        }

        #endregion
    }
}
