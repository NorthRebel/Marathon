namespace Marathon.Core.ViewModel.SponsorRunner.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorRunnerViewModel"/>
    /// </summary>
    public class SponsorRunnerDesignModel : SponsorRunnerViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorRunnerDesignModel Instance => new SponsorRunnerDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorRunnerDesignModel()
        {
            RunnerCharity = new RunnerCharityDesignModel();
            SponsorInfo = new SponsorInfoDesignModel();
            SponsorshipAmount = new SponsorshipAmountDesignModel();
        }

        #endregion
    }
}
