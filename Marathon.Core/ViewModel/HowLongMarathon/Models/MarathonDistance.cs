namespace Marathon.Core.ViewModel.HowLongMarathon.Models
{
    /// <inheritdoc cref="IMarathonDistance"/>
    public class MarathonDistance : IMarathonDistance
    {
        #region Public Properties

        public double Value { get; set; }

        #endregion

        #region Constructor

        public MarathonDistance(double value)
        {
            Value = value;
        }

        #endregion
    }
}
