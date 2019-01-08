namespace Marathon.Core.ViewModel.HowLongMarathon.Models
{
    /// <summary>
    /// Distance of marathon in kilometers
    /// </summary>
    public interface IMarathonDistance
    {
        /// <summary>
        /// Value in kilometers
        /// </summary>
        double Value { get; set; }
    }
}
