using Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList.Design;

namespace Marathon.Core.ViewModel.RunnerSponsorship.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerSponsorshipViewModel"/>
    /// </summary>
    public class RunnerSponsorshipDesignModel : RunnerSponsorshipViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerSponsorshipDesignModel Instance => new RunnerSponsorshipDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerSponsorshipDesignModel()
        {
            Charity = new RunnerCharityDesignModel();
            Sponsorships = new SponsorshipListDesignModel();
        }

        #endregion
    }
}
