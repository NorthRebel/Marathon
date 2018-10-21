namespace Marathon.Core.ViewModel.SponsorRunner.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorshipAmountViewModel"/>
    /// </summary>
    public class SponsorshipAmountDesignModel : SponsorshipAmountViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorshipAmountDesignModel Instance => new SponsorshipAmountDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorshipAmountDesignModel()
        {
            Title = "Сумма пожертвования";

            Ammount = 50;
        }

        #endregion
    }
}
