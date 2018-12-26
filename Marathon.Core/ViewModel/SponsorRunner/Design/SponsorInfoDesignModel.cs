namespace Marathon.Core.ViewModel.SponsorRunner.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorInfoViewModel"/>
    /// </summary>
    public class SponsorInfoDesignModel : SponsorInfoViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorInfoDesignModel Instance => new SponsorInfoDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorInfoDesignModel()
        {
            Title = "Информация о Спонсоре";

            Runners = new[]
            {
                "Kyle Verberder - 122 (Germany)",
                "Migel Oriviera - 159 (Spain)",
                "Иван Прудов - 204 (Russia)",
                "Julie Lawet - 007 (France)"

            };
        }

        #endregion
    }
}
