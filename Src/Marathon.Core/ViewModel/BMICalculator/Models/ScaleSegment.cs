namespace Marathon.Core.ViewModel.BMICalculator.Models
{
    /// <summary>
    /// Segment of scale witch shows BMI
    /// </summary>
    public class ScaleSegment
    {
        #region Public Properties

        /// <summary>
        /// Segment's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Min value of begin scale
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// The background color of the segment in ARGB value
        /// </summary>
        public string Background { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="minValue"><inheritdoc cref="MinValue"/></param>
        /// <param name="background"><inheritdoc cref="Background"/></param>
        /// <param name="description"><inheritdoc cref="Description"/></param>
        public ScaleSegment(double minValue, string background, string description)
        {
            MinValue = minValue;
            Background = background;
            Description = description;
        }

        #endregion
    }
}
