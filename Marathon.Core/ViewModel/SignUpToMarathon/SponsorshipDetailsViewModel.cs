using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{

    /// <summary>
    /// The view model for a sponsorship details part of SignUpToMarathon page
    /// </summary>
    public class SponsorshipDetailsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of charity for sponsorship
        /// </summary>
        public CharityDetailViewModel CharityDetail { get; set; }

        /// <summary>
        /// Sponsorship amount for charity organization
        /// </summary>
        public decimal SponsorshipAmount { get; set; }

        #endregion

        #region Constructor

        public SponsorshipDetailsViewModel()
        {

        }

        #endregion
    }
}
