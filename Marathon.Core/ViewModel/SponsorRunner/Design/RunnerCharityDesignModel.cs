namespace Marathon.Core.ViewModel.SponsorRunner.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerCharityViewModel"/>
    /// </summary>
    public class RunnerCharityDesignModel : RunnerCharityViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerCharityDesignModel Instance => new RunnerCharityDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerCharityDesignModel()
        {
            Title = "Благотворительность";
            CharityName = "Фонд Кошек";
        }

        #endregion
    }
}
