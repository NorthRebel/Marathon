namespace Marathon.Core.ViewModel.BMRCalculator.Models
{
    /// <summary>
    /// Shows daily count of wasted calories by lifestyle
    /// </summary>
    public class LifestyleWasteCalories
    {
        #region Private Members

        /// <summary>
        /// Coefficient for calculate calories by BMR
        /// </summary>
        private readonly double _calculateCoefficient;

        private double _value;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// The background color of the entry in ARGB value
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Calculate wasted calories with coefficient
        /// </summary>
        public double Value
        {
            get => _value;
            set => _value = value * _calculateCoefficient;
        }

        /// <summary>
        /// Name of lifestyle
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructor
        
        public LifestyleWasteCalories(string lifestyle, double calculateCoefficient, string background)
        {
            Name = lifestyle;
            _calculateCoefficient = calculateCoefficient;
            Background = background;
        }

        #endregion
    }
}
