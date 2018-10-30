namespace Marathon.Core.ViewModel.Base
{
    /// <summary>
    /// The view model for show a process of operation execution
    /// </summary>
    public class ProgressViewModel : BaseViewModel
    {
        /// <summary>
        /// Max stages of operation
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Min stages of operation
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Current stage of operation
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// Percent of operation completion between <see cref="MaxValue"/> and <see cref="CurrentValue"/>
        /// </summary>
        public double Percentage { get; set; }

        public void CalculatePercentage()
        {
            Percentage = (CurrentValue / MaxValue) * 100;
        }
    }
}
