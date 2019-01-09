namespace Marathon.Core.ViewModel.SponsorshipConfirm.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorshipConfirmViewModel"/>
    /// </summary>
    public class SponsorshipConfirmDesignModel : SponsorshipConfirmViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorshipConfirmDesignModel Instance => new SponsorshipConfirmDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorshipConfirmDesignModel()
        {
            RunnerName = "Иван Прудов - 204 (Russia)";
            RunnerCharityName = "Фонд кошек";
            Amount = 50;
        }

        #endregion
    }
}
