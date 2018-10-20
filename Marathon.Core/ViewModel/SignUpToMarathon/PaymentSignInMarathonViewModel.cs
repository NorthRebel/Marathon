using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.MarathonOptions;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// The view model for a payment detail part of SignUpToMarathon page
    /// </summary>
    public class PaymentSignInMarathonViewModel : OptionsViewModel
    {
        #region Public Properties

        /// <summary>
        /// Payment of sign up to marathon
        /// </summary>
        public decimal Payment { get; set; }

        #endregion
    }
}
