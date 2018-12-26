namespace Marathon.Core.ViewModel.SignUpToMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="PaymentSignInMarathonViewModel"/>
    /// </summary>
    public class PaymentSignInMarathonDesignModel : PaymentSignInMarathonViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PaymentSignInMarathonDesignModel Instance => new PaymentSignInMarathonDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentSignInMarathonDesignModel()
        {
            Payment = 660;
        }

        #endregion
    }
}
