using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList
{
    /// <summary>
    /// The view model for runner sponsorship list item
    /// </summary>
    public class SponsorshipListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Name of sponsor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Amount from sponsor
        /// </summary>
        public decimal Ammount { get; set; }
    }
}
