namespace Marathon.Core.ViewModel.RunnerSponsorship.SponsorshipList.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorshipListItemViewModel"/>
    /// </summary>
    public class SponsorshipListItemDesignModel : SponsorshipListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorshipListItemDesignModel Instance => new SponsorshipListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorshipListItemDesignModel()
        {
            Name = "Dave Jonson";
            Ammount = 720m;
        }

        #endregion
    }
}
