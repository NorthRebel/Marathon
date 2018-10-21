using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.MarathonOptions;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{

    /// <summary>
    /// The view model for a sponsorship details part of SignUpToMarathon page
    /// </summary>
    public class SponsorshipDetailsViewModel : OptionsViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of charity for sponsorship
        /// </summary>
        public CharityDetailViewModel CharityDetail { get; set; }

        /// <summary>
        /// Sponsorship amount for charity organization
        /// </summary>
        public EntryViewModel<decimal> SponsorshipAmount { get; set; }

        #endregion

        #region Constructor

        public SponsorshipDetailsViewModel()
        {

        }

        #endregion
    }
}
