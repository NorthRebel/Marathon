using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.RunnerSponsorship.Models;
using Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList;

namespace Marathon.Core.ViewModel.RunnerSponsorship
{
    /// <summary>
    /// The view model for runner sponsorship page
    /// </summary>
    public class RunnerSponsorshipViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Information about runner charity
        /// </summary>
        public RunnerCharityViewModel Charity { get; set; }

        /// <summary>
        /// List of sponsors which give amount for current runner
        /// </summary>
        public SponsorshipListViewModel Sponsorships { get; set; }

        #endregion

        #region Constructor

        public RunnerSponsorshipViewModel()
        {
            PageCaption = new PageCaptionViewModel("Мои спонсоры", "Здесь показаны все ваши спонсоры в Marathon Skills 2016.");
        }

        #endregion
    }
}
