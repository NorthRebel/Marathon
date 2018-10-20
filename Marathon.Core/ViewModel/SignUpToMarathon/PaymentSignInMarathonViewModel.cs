using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.SignUpToMarathon
{
    /// <summary>
    /// The view model for a payment detail part of SignUpToMarathon page
    /// </summary>
    public class PaymentSignInMarathonViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Title of the options list
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Payment of sign up to marathon
        /// </summary>
        public decimal Payment { get; set; }

        #endregion
    }
}
