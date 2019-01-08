using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerSponsorship.Models
{
    /// <summary>
    /// The view model for a control which presents runner charity
    /// </summary>
    public class RunnerCharityViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of charity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo of charity
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Description of charity
        /// </summary>
        public string Description { get; set; }
    }
}
