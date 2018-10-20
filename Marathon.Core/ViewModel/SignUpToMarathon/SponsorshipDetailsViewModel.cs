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
            Title = "Детали спонсорства";

            // TODO: Remove dummy data

            #region Fill dummy data to viewModel

            CharityDetail = new CharityDetailViewModel("Взнос")
            {
                Value = new string[]
                {
                    "Фонд А",
                    "Фонд Б",
                    "Фонд В",
                }
            };

            SponsorshipAmount = new EntryViewModel<decimal>("Сумма взноса")
            {
                Value = 500
            };

            #endregion
        }

        #endregion
    }
}
