using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList
{
    /// <summary>
    /// The view model for runner sponsorship list
    /// </summary>
    public class SponsorshipListViewModel : BaseViewModel
    {
        public IEnumerable<SponsorshipListItemViewModel> Items { get; set; }
    }
}
