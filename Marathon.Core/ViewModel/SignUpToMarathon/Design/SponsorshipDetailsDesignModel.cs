using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.SignUpToMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SponsorshipDetailsViewModel"/>
    /// </summary>
    public class SponsorshipDetailsDesignModel : SponsorshipDetailsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SponsorshipDetailsDesignModel Instance => new SponsorshipDetailsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SponsorshipDetailsDesignModel()
        {
            Title = "Детали спонсорства";

            CharityDetail = CharityDetailDesignModel.Instance;

            SponsorshipAmount = new EntryViewModel<decimal>("Сумма взноса")
            {
                Value = 500
            };
        }

        #endregion
    }
}
